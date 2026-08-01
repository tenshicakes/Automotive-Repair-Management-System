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
            // Auto-change labels
            vhclmodellbl.Text = vehicleModel;
            platenumberlbl.Text = plateNumber;
            datefinishlbl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

     
            updatestatus.Text = "Finished"; // Default to Finished or Pending

            dtPartsUsed.Columns.Add("PartName", typeof(string));
            dtPartsUsed.Columns.Add("Quantity", typeof(int));
            dtPartsUsed.Columns.Add("Price", typeof(decimal));
            partsusedgrid.DataSource = dtPartsUsed;
        }


        // Event handler for the "Add Parts" button click
        private void addpartsbtn_Click(object sender, EventArgs e)
        {
            AddParts addparts = new AddParts(dtPartsUsed);
            addparts.ShowDialog();
        }


        // Event handler for the "Save Job" button click
        private void savejobbtn_Click(object sender, EventArgs e)
        {
            string status = updatestatus.Text;
            string solution = solution_txtbox.Text.Trim();
            string dateFinished = datefinishlbl.Text;

            // Compile parts used into a text string format (e.g., "Oil Filter x2, Spark Plug x4") or leave null if empty
            string partsUsedText = null;
            if (dtPartsUsed.Rows.Count > 0)
            {
                List<string> partNamesList = new List<string>();
                foreach (DataRow row in dtPartsUsed.Rows)
                {
                    string pName = row["PartName"].ToString();
                    int pQty = Convert.ToInt32(row["Quantity"]);

                    // Optional: If you want to include quantities in the text like "Oil Filter (2)" change this line. 
                    // Otherwise, just the name: partNamesList.Add(pName);
                    partNamesList.Add($"{pName} (Qty: {pQty})");
                }
                partsUsedText = string.Join(", ", partNamesList);
            }

            // 1. Prepare queries for transaction (Update ServiceLogs AND Deduct SpareParts stock)
            // Build dynamic update queries or a transaction array
            List<string> queryList = new List<string>();
            List<SqlParameter[]> paramList = new List<SqlParameter[]>();

            // Main update query for ServiceLogs
            string updateLogQuery = @"
                UPDATE ServiceLogs 
                SET Status = @Status, Solution = @Solution, PartsUsed = @PartsUsed, DateFinished = @DateFinished 
                WHERE LogID = @ServiceLogID";

            queryList.Add(updateLogQuery);
            paramList.Add(new SqlParameter[] {
                new SqlParameter("@Status", status),
                new SqlParameter("@Solution", string.IsNullOrEmpty(solution) ? (object)DBNull.Value : solution),
                new SqlParameter("@PartsUsed", string.IsNullOrEmpty(partsUsedText) ? (object)DBNull.Value : partsUsedText),
                new SqlParameter("@DateFinished", dateFinished),
                new SqlParameter("@ServiceLogID", _serviceLogID)
            });

            // Add queries to deduct stock quantities from SpareParts table for each part used
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

            // Execute via DatabaseHelper transaction
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

        }

        private void foxLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
