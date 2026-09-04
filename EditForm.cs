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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
            SetupGridStyle();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }

        private void SetupGridStyle()
        {
            editinventorygrid.BackgroundColor = Color.White;
            editinventorygrid.BorderStyle = BorderStyle.None;
            editinventorygrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            editinventorygrid.RowHeadersVisible = false;
            editinventorygrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            editinventorygrid.AllowUserToAddRows = false;
            editinventorygrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            editinventorygrid.DefaultCellStyle.BackColor = Color.White;
            editinventorygrid.DefaultCellStyle.ForeColor = Color.Black;
            editinventorygrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            editinventorygrid.DefaultCellStyle.SelectionForeColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            editinventorygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            editinventorygrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            editinventorygrid.EnableHeadersVisualStyles = false;
            editinventorygrid.RowTemplate.Height = 40;
        }
    }
}
