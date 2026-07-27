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
        public AddParts()
        {
            InitializeComponent();
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
            availpartsgrid.DataSource = dt;

            availpartsgrid.Columns["PartName"].HeaderText = "Part Name";
            availpartsgrid.Columns["StockQuantity"].HeaderText = "Stocks";
            availpartsgrid.Columns["Price"].HeaderText = "Price";
        }

        private void SetupInventoryAddPartsGridStyle()
        {
            availpartsgrid.BackgroundColor = Color.White;
            availpartsgrid.BorderStyle = BorderStyle.None;
            availpartsgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            availpartsgrid.RowHeadersVisible = false;
            availpartsgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            availpartsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availpartsgrid.MultiSelect = true;
            availpartsgrid.ReadOnly = true;
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
    }
    }

