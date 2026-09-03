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
            string query = "SELECT PartName, StockQuantity, Price FROM SpareParts";
            DataTable dt = DatabaseHelper.GetTable(query);
            inventorygrid.DataSource = dt;

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
    }
}
