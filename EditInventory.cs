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
    public partial class EditInventory : Form
    {
        public EditInventory()
        {
            InitializeComponent();
            SetupInventoryGridStyle();
        }

        private void EditInventory_Load(object sender, EventArgs e)
        {
            LoadProductsToInventoryGrid();
            SetupInventoryGridStyle();
        }

        private void LoadProductsToInventoryGrid()
        {
            string query = "SELECT PartID, PartName, StockQuantity, Price FROM SpareParts";
            DataTable dt = DatabaseHelper.GetTable(query);
            inventorygrid.DataSource = dt;

            inventorygrid.Columns["PartID"].HeaderText = "Part ID";
            inventorygrid.Columns["PartName"].HeaderText = "Part Name";
            inventorygrid.Columns["StockQuantity"].HeaderText = "Stocks";
            inventorygrid.Columns["Price"].HeaderText = "Price";
        }

        private void SetupInventoryGridStyle()
        {
            inventorygrid.BackgroundColor = Color.White;
            inventorygrid.BorderStyle = BorderStyle.None;
            inventorygrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            inventorygrid.RowHeadersVisible = false;
            inventorygrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inventorygrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inventorygrid.MultiSelect = true;
            inventorygrid.ReadOnly = true;
            inventorygrid.AllowUserToAddRows = false;
            inventorygrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            inventorygrid.DefaultCellStyle.BackColor = Color.White;
            inventorygrid.DefaultCellStyle.ForeColor = Color.Black;
            inventorygrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            inventorygrid.DefaultCellStyle.SelectionForeColor = Color.White;
            inventorygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            inventorygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            inventorygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            inventorygrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            inventorygrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            inventorygrid.EnableHeadersVisualStyles = false;
            inventorygrid.RowTemplate.Height = 40;
        }

        private void addstockbtn_Click(object sender, EventArgs e)
        {
            OpenStockForm("IN");
        }

        private void reducestockbtn_Click(object sender, EventArgs e)
        {
            OpenStockForm("OUT");
        }

        private void OpenStockForm(string actionType)
        {
            if (inventorygrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the inventory.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Prevent 0-stock items from passing to a Stock-Out action
            if (actionType == "OUT")
            {
                foreach (DataGridViewRow row in inventorygrid.SelectedRows)
                {
                    int currentStock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                    if (currentStock <= 0)
                    {
                        string partName = row.Cells["PartName"].Value?.ToString() ?? "Selected item";
                        MessageBox.Show($"'{partName}' has 0 stock. You cannot perform a stock-out on depleted items. Please deselect it.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Aborts opening the form completely
                    }
                }
            }

            // Create a temporary DataTable to hold the selected items to pass to the popup
            DataTable dtSelected = new DataTable();
            dtSelected.Columns.Add("PartID", typeof(int));
            dtSelected.Columns.Add("PartName", typeof(string));
            dtSelected.Columns.Add("StockQuantity", typeof(int));

            foreach (DataGridViewRow row in inventorygrid.SelectedRows)
            {
                dtSelected.Rows.Add(
                    row.Cells["PartID"].Value,
                    row.Cells["PartName"].Value,
                    row.Cells["StockQuantity"].Value
                );
            }

            using (StockForm stockForm = new StockForm(dtSelected, actionType))
            {
                if (stockForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProductsToInventoryGrid();
                }
            }
        }
    }
}
