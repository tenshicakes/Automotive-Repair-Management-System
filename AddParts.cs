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
    public partial class AddParts : Form
    {
        private DataTable _targetPartsUsedTable;
        public AddParts(DataTable targetPartsUsedTable)
        {
            InitializeComponent();
            _targetPartsUsedTable = targetPartsUsedTable;
            LoadInventoryToAddPartsGrid();
        }

        private void AddParts_Load(object sender, EventArgs e)
        {
            LoadInventoryToAddPartsGrid();
            SetupInventoryAddPartsGridStyle();


        }

        private void LoadInventoryToAddPartsGrid()
        {
            string query = "SELECT PartName, StockQuantity, Price FROM SpareParts";
            DataTable dt = DatabaseHelper.GetTable(query);

            // 1. Add a custom interactive Quantity column to the DataTable if it doesn't already exist
            if (!dt.Columns.Contains("Quantity"))
            {
                DataColumn qtyColumn = new DataColumn("Quantity", typeof(int));
                qtyColumn.DefaultValue = 1; // Default typed quantity
                dt.Columns.Add(qtyColumn);
            }

            // 2. SET THE DATASOURCE FIRST so the columns are actually created in the grid
            availpartsgrid.DataSource = dt;

            // 3. NOW customize the column headers safely (using DataPropertyName or Column Name)
            if (availpartsgrid.Columns["PartName"] != null)
                availpartsgrid.Columns["PartName"].HeaderText = "Part Name";

            if (availpartsgrid.Columns["StockQuantity"] != null)
                availpartsgrid.Columns["StockQuantity"].HeaderText = "Stocks";

            if (availpartsgrid.Columns["Price"] != null)
                availpartsgrid.Columns["Price"].HeaderText = "Price";

            if (availpartsgrid.Columns["Quantity"] != null)
                availpartsgrid.Columns["Quantity"].HeaderText = "Quantity";

            // 4. Configure read-only and editable states
            availpartsgrid.ReadOnly = false;
            foreach (DataGridViewColumn col in availpartsgrid.Columns)
            {
                if (col.Name == "Quantity" || col.DataPropertyName == "Quantity")
                {
                    col.ReadOnly = false;
                    col.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow; // Visual cue that it's editable
                }
                else
                {
                    col.ReadOnly = true;
                }
            }
        }

            
        

        private void SetupInventoryAddPartsGridStyle()
        {
            availpartsgrid.BackgroundColor = Color.White;
            availpartsgrid.BorderStyle = BorderStyle.None;
            availpartsgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            availpartsgrid.RowHeadersVisible = false;
            availpartsgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            availpartsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            availpartsgrid.AllowUserToAddRows = false;


            availpartsgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            availpartsgrid.DefaultCellStyle.BackColor = Color.White;
            availpartsgrid.DefaultCellStyle.ForeColor = Color.Black;
            availpartsgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            availpartsgrid.DefaultCellStyle.SelectionForeColor = Color.White;

            availpartsgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            availpartsgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            availpartsgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            availpartsgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            availpartsgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;


            availpartsgrid.EnableHeadersVisualStyles = false;


            availpartsgrid.RowTemplate.Height = 40;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (availpartsgrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one full row.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Loop through selected rows
            foreach (DataGridViewRow row in availpartsgrid.SelectedRows)
            {
                if (row.IsNewRow) continue;

                string partName = row.Cells["PartName"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                int stockQuantity = Convert.ToInt32(row.Cells["StockQuantity"].Value);

                // 1. Validate that the quantity is a valid integer
                int qty = 1;
                if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out int parsedQty))
                {
                    qty = parsedQty;
                }
                else
                {
                    MessageBox.Show($"Invalid quantity format entered for '{partName}'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stops execution completely
                }

                // 2. Limiter: Prevent negative or zero numbers
                if (qty <= 0)
                {
                    MessageBox.Show($"Quantity for '{partName}' must be greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stops execution
                }

                // 3. Limiter: Prevent entering more than available StockQuantity
                if (qty > stockQuantity)
                {
                    MessageBox.Show($"Entered quantity ({qty}) for '{partName}' exceeds available stock ({stockQuantity}).", "Stock Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stops execution
                }

                // Check if part is already added to the local list, and make sure cumulative quantity doesn't exceed stock
                int existingQtyInList = 0;
                DataRow targetExistingRow = null;
                foreach (DataRow existingRow in _targetPartsUsedTable.Rows)
                {
                    if (existingRow["PartName"].ToString() == partName)
                    {
                        existingQtyInList = Convert.ToInt32(existingRow["Quantity"]);
                        targetExistingRow = existingRow;
                        break;
                    }
                }

                if (targetExistingRow != null)
                {
                    int totalRequested = existingQtyInList + qty;
                    if (totalRequested > stockQuantity)
                    {
                        MessageBox.Show($"Total quantity for '{partName}' ({totalRequested}) would exceed available stock ({stockQuantity}).", "Stock Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    targetExistingRow["Quantity"] = totalRequested;
                }
                else
                {
                    _targetPartsUsedTable.Rows.Add(partName, qty, price);
                }
            }

            this.Close();
        }
    }
}
    

