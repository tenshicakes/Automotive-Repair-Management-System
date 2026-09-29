using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class FinishedJob : Form
    {
        public FinishedJob()
        {
            InitializeComponent();
            SetupFinishedJobOrderStyle();
        }

        private void FinishedJob_Load(object sender, EventArgs e)
        {
            LoadFinishedJobOrdersToGrid();
            SetupFinishedJobOrderStyle();   
        }

        private void LoadFinishedJobOrdersToGrid()
        {
            try
            {
               
                string query = @"
                    SELECT s.LogID, v.VehicleModel, v.PlateNumber, s.Issue, s.FixedBy, 
                           s.DateLogged, s.DateFinished, p.TotalAmount 
                    FROM ServiceLogs s 
                    INNER JOIN VehicleInfo v ON s.VehicleID = v.VehicleID 
                    INNER JOIN PaymentLogs p ON s.LogID = p.LogID 
                    WHERE s.Status = 'Finished'";

                List<SqlParameter> parameters = new List<SqlParameter>();

         
                if (dtpfrom.Checked)
                {
                    query += " AND s.DateFinished >= @FromDate";
                    parameters.Add(new SqlParameter("@FromDate", dtpfrom.Value.Date));
                }

                if (dtpto.Checked)
                {
                    query += " AND s.DateFinished <= @ToDate";
                   
                    parameters.Add(new SqlParameter("@ToDate", dtpto.Value.Date.AddDays(1).AddTicks(-1)));
                }

                query += " ORDER BY s.DateFinished DESC";

                
                DataTable dt = DatabaseHelper.GetTable(query, parameters.ToArray());
                finishedjobgrid.DataSource = dt;

                
                if (finishedjobgrid.Columns.Count > 0)
                {
                    finishedjobgrid.Columns["LogID"].Visible = false; 

                    finishedjobgrid.Columns["VehicleModel"].HeaderText = "Vehicle Model";
                    finishedjobgrid.Columns["PlateNumber"].HeaderText = "Plate Number";
                    finishedjobgrid.Columns["Issue"].HeaderText = "Issue";
                    finishedjobgrid.Columns["FixedBy"].HeaderText = "Mechanic";
                    finishedjobgrid.Columns["DateLogged"].HeaderText = "Date Logged";
                    finishedjobgrid.Columns["DateFinished"].HeaderText = "Date Finished";
                    finishedjobgrid.Columns["TotalAmount"].HeaderText = "Revenue";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading finished jobs: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // DATE FILTER TRIGGERS
        // ==========================================
    
        private void dtpfrom_ValueChanged(object sender, EventArgs e)
        {
            LoadFinishedJobOrdersToGrid();
        }

        private void dtpto_ValueChanged(object sender, EventArgs e)
        {
            LoadFinishedJobOrdersToGrid();
        }

        private void SetupFinishedJobOrderStyle()
        {

            finishedjobgrid.BackgroundColor = Color.White;
            finishedjobgrid.BorderStyle = BorderStyle.None;
            finishedjobgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            finishedjobgrid.RowHeadersVisible = false;
            finishedjobgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            finishedjobgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            finishedjobgrid.ReadOnly = true;
            finishedjobgrid.AllowUserToAddRows = false;

            finishedjobgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            finishedjobgrid.DefaultCellStyle.BackColor = Color.White;
            finishedjobgrid.DefaultCellStyle.ForeColor = Color.Black;
            finishedjobgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            finishedjobgrid.DefaultCellStyle.SelectionForeColor = Color.White;

            finishedjobgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            finishedjobgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            finishedjobgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            finishedjobgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            finishedjobgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            finishedjobgrid.EnableHeadersVisualStyles = false;
            finishedjobgrid.RowTemplate.Height = 40;
        }
        


        private void foxbutton_Click(object sender, EventArgs e)
        {

        }

        private void finishedjobgrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void finishedjobgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reportbtn_Click(object sender, EventArgs e)
        {
    
            if (finishedjobgrid.Rows.Count == 0)
            {
                MessageBox.Show("There are no records currently displayed to generate a report.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Document (*.pdf)|*.pdf";
                sfd.FileName = $"RevenueReport_{DateTime.Now:yyyyMMdd}.pdf";
                sfd.Title = "Save Revenue Report";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (PdfWriter writer = new PdfWriter(sfd.FileName))
                        using (PdfDocument pdf = new PdfDocument(writer))
                        using (Document document = new Document(pdf))
                        {
                      
                            iText.Kernel.Font.PdfFont boldFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                            iText.Kernel.Font.PdfFont italicFont = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_OBLIQUE);

                            // ==========================================
                            // HEADER
                            // ==========================================
                            document.Add(new Paragraph("PRO77 Auto Shop")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(18)
                                .SetFont(boldFont));

                            document.Add(new Paragraph("Completed Jobs & Revenue Report")
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(12)
                                .SetMarginBottom(5));

       
                            string filterNote = "Showing All Time";
                            if (dtpfrom.Checked && dtpto.Checked)
                                filterNote = $"Filtered: {dtpfrom.Value:MM/dd/yyyy} to {dtpto.Value:MM/dd/yyyy}";
                            else if (dtpfrom.Checked)
                                filterNote = $"Filtered: From {dtpfrom.Value:MM/dd/yyyy}";
                            else if (dtpto.Checked)
                                filterNote = $"Filtered: Up to {dtpto.Value:MM/dd/yyyy}";

                            document.Add(new Paragraph(filterNote)
                                .SetTextAlignment(TextAlignment.CENTER)
                                .SetFontSize(10)
                                .SetFont(italicFont)
                                .SetMarginBottom(20));

                            // ==========================================
                            // DATA TABLE
                            // ==========================================
                           
                            Table table = new Table(new float[] { 2, 2, 2, 3, 2, 2 }).UseAllAvailableWidth().SetMarginBottom(15);

                            string[] headers = { "Date Finished", "Vehicle", "Plate No.", "Issue", "Mechanic", "Revenue" };
                            foreach (string head in headers)
                            {
                                table.AddHeaderCell(new Cell()
                                    .Add(new Paragraph(head).SetFont(boldFont).SetFontSize(10))
                                    .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY));
                            }

                            decimal grandTotal = 0;


                            foreach (DataGridViewRow row in finishedjobgrid.Rows)
                            {
                                if (row.IsNewRow) continue;

                                string dateStr = row.Cells["DateFinished"].Value != DBNull.Value
                                    ? Convert.ToDateTime(row.Cells["DateFinished"].Value).ToString("MM/dd/yyyy")
                                    : "N/A";

                                string vehicle = row.Cells["VehicleModel"].Value?.ToString() ?? "";
                                string plate = row.Cells["PlateNumber"].Value?.ToString() ?? "";
                                string issue = row.Cells["Issue"].Value?.ToString() ?? "";
                                string mechanic = row.Cells["FixedBy"].Value?.ToString() ?? "";

                                decimal amount = Convert.ToDecimal(row.Cells["TotalAmount"].Value);
                                grandTotal += amount;

                          
                                string formattedAmount = "PHP " + amount.ToString("N2");

                                table.AddCell(new Cell().Add(new Paragraph(dateStr).SetFontSize(9)));
                                table.AddCell(new Cell().Add(new Paragraph(vehicle).SetFontSize(9)));
                                table.AddCell(new Cell().Add(new Paragraph(plate).SetFontSize(9)));
                                table.AddCell(new Cell().Add(new Paragraph(issue).SetFontSize(9)));
                                table.AddCell(new Cell().Add(new Paragraph(mechanic).SetFontSize(9)));
                                table.AddCell(new Cell().Add(new Paragraph(formattedAmount).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)));
                            }

                            document.Add(table);

                            // ==========================================
                            // SUMMARY & FOOTER
                            // ==========================================
                            document.Add(new Paragraph(new string('_', 78)).SetMarginBottom(5));

                            document.Add(new Paragraph($"GRAND TOTAL: PHP {grandTotal.ToString("N2")}")
                                .SetTextAlignment(TextAlignment.RIGHT)
                                .SetFontSize(12)
                                .SetFont(boldFont)
                                .SetMarginBottom(30));

                            document.Add(new Paragraph("Generated By: __________________________")
                                .SetFontSize(10)
                                .SetMarginBottom(5));

                            document.Add(new Paragraph("(Authorized Shop Personnel)")
                                .SetFontSize(9)
                                .SetFontColor(iText.Kernel.Colors.ColorConstants.GRAY));
                        }

                        MessageBox.Show("Report successfully generated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Cannot overwrite the PDF because it is open in another program. Please close it and try again.", "File In Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while generating the PDF: " + ex.Message, "Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
