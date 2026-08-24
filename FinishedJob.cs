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
    public partial class FinishedJob : Form
    {
        public FinishedJob()
        {
            InitializeComponent();
        }

        private void FinishedJob_Load(object sender, EventArgs e)
        {
            LoadFinishedJobOrdersToGrid();
            SetupFinishedJobOrderStyle();   
        }

        private void LoadFinishedJobOrdersToGrid()
        {
            string query = "SELECT s.LogID, v.VehicleModel, v.PlateNumber, s.Issue, s.FixedBy, s.LoggedBy, s.DateLogged, s.DateFinished FROM VehicleInfo v INNER JOIN ServiceLogs s ON v.VehicleID = s.VehicleID WHERE s.Status = 'Finished'";
            DataTable dt = DatabaseHelper.GetTable(query);
            finishedjobgrid.DataSource = dt;


            finishedjobgrid.Columns["VehicleModel"].HeaderText = "Vehicle Model";
            finishedjobgrid.Columns["PlateNumber"].HeaderText = "Plate Number";
            finishedjobgrid.Columns["Issue"].HeaderText = "Issue";
            finishedjobgrid.Columns["FixedBy"].HeaderText = "Fixed By";
            finishedjobgrid.Columns["LoggedBy"].HeaderText = "Logged By";
            finishedjobgrid.Columns["DateLogged"].HeaderText = "Date Logged";
            finishedjobgrid.Columns["DateFinished"].HeaderText = "Date Finished";

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

        
    }
}
