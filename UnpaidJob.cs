using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class UnpaidJob : Form
    {
        public UnpaidJob()
        {
            InitializeComponent();
        }

        private void UnpaidJob_Load(object sender, EventArgs e)
        {
            LoadUnpaidJobsToGrid();
            SetupUnpaidJobGridStyle();
        }


        //==========================
        // UPDATE BUTTON
        //==========================
        private void addbtn_Click(object sender, EventArgs e)
        {
            // 1. Validate that a row is actually selected
            if (unpaidjobgrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an unpaid job order first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Grab the selected row
            DataGridViewRow selectedRow = unpaidjobgrid.SelectedRows[0];
            if (selectedRow.IsNewRow) return;

            // 3. Extract the PartsUsed string (safely handling nulls if no parts were used)
            string partsUsed = selectedRow.Cells["PartsUsed"].Value?.ToString() ?? string.Empty;
            string logID = selectedRow.Cells["LogID"].Value.ToString(); // You might also need LogID for saving payment later!

            // 4. Open UpdateUnpaidJob and pass the data
            UpdateUnpaidJob updateForm = new UpdateUnpaidJob(logID, partsUsed);
            updateForm.ShowDialog();

            // Optional: Refresh the grid after closing the form in case payment was saved
            LoadUnpaidJobsToGrid();
        }
        
        

        private void LoadUnpaidJobsToGrid()
        {
            string query = @"
            SELECT 
            s.LogID, 
            v.VehicleModel, 
            v.PlateNumber, 
            s.Issue, 
            s.Solution, 
            s.PartsUsed, 
            s.Status, 
            s.FixedBy, 
            p.TotalAmount, 
            p.PaymentDate, 
            p.ProcessedBy 
            FROM ServiceLogs s 
            INNER JOIN VehicleInfo v ON s.VehicleID = v.VehicleID 
            LEFT JOIN PaymentLogs p ON s.LogID = p.LogID 
            WHERE p.LogID IS NULL;";

            DataTable dt = DatabaseHelper.GetTable(query);
            unpaidjobgrid.DataSource = dt;
            unpaidjobgrid.Columns["LogID"].HeaderText = "Log ID";
            unpaidjobgrid.Columns["VehicleModel"].HeaderText = "Vehicle Model";
            unpaidjobgrid.Columns["PlateNumber"].HeaderText = "Plate Number";
            unpaidjobgrid.Columns["Issue"].HeaderText = "Issue";
            unpaidjobgrid.Columns["Solution"].HeaderText = "Solution";
            unpaidjobgrid.Columns["PartsUsed"].HeaderText = "Parts Used";
            unpaidjobgrid.Columns["Status"].HeaderText = "Status";
            unpaidjobgrid.Columns["FixedBy"].HeaderText = "Fixed By";
            unpaidjobgrid.Columns["TotalAmount"].HeaderText = "Total Amount";
            unpaidjobgrid.Columns["PaymentDate"].HeaderText = "Payment Date";
            unpaidjobgrid.Columns["ProcessedBy"].HeaderText = "Processed By";
        }


        private void SetupUnpaidJobGridStyle()
        {
            unpaidjobgrid.BackgroundColor = Color.White;
            unpaidjobgrid.BorderStyle = BorderStyle.None;
            unpaidjobgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            unpaidjobgrid.RowHeadersVisible = false;
            unpaidjobgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            unpaidjobgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            unpaidjobgrid.ReadOnly = true;
            unpaidjobgrid.AllowUserToAddRows = false;

            unpaidjobgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            unpaidjobgrid.DefaultCellStyle.BackColor = Color.White;
            unpaidjobgrid.DefaultCellStyle.ForeColor = Color.Black;
            unpaidjobgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            unpaidjobgrid.DefaultCellStyle.SelectionForeColor = Color.White;

            unpaidjobgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            unpaidjobgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            unpaidjobgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            unpaidjobgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            unpaidjobgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            unpaidjobgrid.EnableHeadersVisualStyles = false;
            unpaidjobgrid.RowTemplate.Height = 40;
        }

    }
}
