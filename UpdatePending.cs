using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class UpdatePending : Form
    {
            private string _serviceLogID;
            private DataTable dtPartsUsed = new DataTable();
        public UpdatePending(string serviceLogID, string vehicleModel, string plateNumber)
        {
            InitializeComponent();
            _serviceLogID = serviceLogID;
          
            vhclmodellbl.Text = vehicleModel;
            platenumberlbl.Text = plateNumber;
            datefinishlbl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

     
            updatestatus.Text = "Finished"; 

            dtPartsUsed.Columns.Add("PartName", typeof(string));
            dtPartsUsed.Columns.Add("Quantity", typeof(int));
            dtPartsUsed.Columns.Add("Price", typeof(decimal));
            partsusedgrid.DataSource = dtPartsUsed;
        }



        private void PartsUsedGridDesign()
        {
            partsusedgrid.BackgroundColor = Color.White;
            partsusedgrid.BorderStyle = BorderStyle.None;
            partsusedgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            partsusedgrid.RowHeadersVisible = false;
            partsusedgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            partsusedgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            partsusedgrid.MultiSelect = true;
            partsusedgrid.ReadOnly = true;
            partsusedgrid.AllowUserToAddRows = false;
            partsusedgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            partsusedgrid.DefaultCellStyle.BackColor = Color.White;
            partsusedgrid.DefaultCellStyle.ForeColor = Color.Black;
            partsusedgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            partsusedgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            partsusedgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            partsusedgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            partsusedgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            partsusedgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            partsusedgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            partsusedgrid.EnableHeadersVisualStyles = false;
            partsusedgrid.RowTemplate.Height = 40;
        }
        

        private void addpartsbtn_Click(object sender, EventArgs e)
        {
            AddParts addparts = new AddParts(dtPartsUsed);
            addparts.ShowDialog();
        }


   
        private void savejobbtn_Click(object sender, EventArgs e)
{
    string status = updatestatus.Text;
    string solution = solution_txtbox.Text.Trim();
    string fixedBy = fixedby_txtbox.Text.Trim(); 
    string dateFinished = datefinishlbl.Text;

    string partsUsedText = null;
    if (dtPartsUsed.Rows.Count > 0)
    {
        List<string> partNamesList = new List<string>();
        foreach (DataRow row in dtPartsUsed.Rows)
        {
            string pName = row["PartName"].ToString();
            int pQty = Convert.ToInt32(row["Quantity"]);

            partNamesList.Add($"{pName} (Qty: {pQty})");
        }
        partsUsedText = string.Join(", ", partNamesList);
    }

 
    List<string> queryList = new List<string>();
    List<SqlParameter[]> paramList = new List<SqlParameter[]>();

    string updateLogQuery = @"
        UPDATE ServiceLogs 
        SET Status = @Status, 
            Solution = @Solution, 
            PartsUsed = @PartsUsed, 
            DateFinished = @DateFinished, 
            FixedBy = @FixedBy 
        WHERE LogID = @ServiceLogID";

    queryList.Add(updateLogQuery);
    paramList.Add(new SqlParameter[] {
        new SqlParameter("@Status", status),
        new SqlParameter("@Solution", string.IsNullOrEmpty(solution) ? (object)DBNull.Value : solution),
        new SqlParameter("@PartsUsed", string.IsNullOrEmpty(partsUsedText) ? (object)DBNull.Value : partsUsedText),
        new SqlParameter("@DateFinished", dateFinished),
        new SqlParameter("@FixedBy", string.IsNullOrEmpty(fixedBy) ? (object)DBNull.Value : fixedBy), 
        new SqlParameter("@ServiceLogID", _serviceLogID)
    });

    foreach (DataRow row in dtPartsUsed.Rows)
    {
        string partName = row["PartName"].ToString();
        int qtyUsed = Convert.ToInt32(row["Quantity"]);

        string stockDeductQuery = @"
            UPDATE SpareParts 
            SET StockQuantity = StockQuantity - @QtyUsed 
            WHERE PartName = @PartName";

        queryList.Add(stockDeductQuery);
        paramList.Add(new SqlParameter[] {
            new SqlParameter("@QtyUsed", qtyUsed),
            new SqlParameter("@PartName", partName)
        });
    }


    bool success = DatabaseHelper.ExecuteTransaction(queryList.ToArray(), paramList.ToArray());

    if (success)
    {
        MessageBox.Show("Job order updated and inventory deducted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Close();
    }
    else
    {
        MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


        private void UpdatePending_Load(object sender, EventArgs e)
        {
            PartsUsedGridDesign();
        }

        private void foxLabel6_Click(object sender, EventArgs e)
        {

        }

        private void removepartsbtn_Click(object sender, EventArgs e)
        {
        
            if (partsusedgrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one part to remove.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            List<DataRow> rowsToRemove = new List<DataRow>();

            foreach (DataGridViewRow row in partsusedgrid.SelectedRows)
            {
                if (row.IsNewRow) continue;

                if (row.DataBoundItem is DataRowView drv)
                {
                    rowsToRemove.Add(drv.Row);
                }
            }

       
            foreach (DataRow dr in rowsToRemove)
            {
                dr.Table.Rows.Remove(dr);
            }
        }
    }
}
