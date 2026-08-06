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
    public partial class ViewVehicleHistory : Form
    {
        private int _vehicleId;
        private string _vehicleModel;
        private string _plateNumber;
        public ViewVehicleHistory(int vehicleId, string vehicleModel, string plateNumber)
        {
            InitializeComponent();
            _vehicleId = vehicleId;
            _vehicleModel = vehicleModel;
            _plateNumber = plateNumber;

            // 1. Auto-change your labels based on the clicked vehicle
            vehiclenamelbl.Text = _vehicleModel;     
            vehicleplatelbl.Text = _plateNumber;      

            // 2. Load the combined history data into the grid
            LoadHistoryGrid();
            SetupHistoryGridStyle();
        }
        private void LoadHistoryGrid()
        {
            // SQL query: Pulls ServiceLogs for this vehicle and joins PaymentInfo via LogID.
            // Explicitly selects only the columns you want (excluding VehicleID, PaymentID, and LogID).
            string query = @"
                SELECT 
                    s.LogID,
                    s.Issue, 
                    s.Solution, 
                    s.PartsUsed, 
                    s.Status, 
                    s.LoggedBy, 
                    s.FixedBy,
                    s.DateLogged, 
                    s.DateFinished,
                    p.TotalAmount, 
                    p.PaymentDate, 
                    p.ProcessedBy
                FROM ServiceLogs s
                LEFT JOIN PaymentLogs p ON s.LogID = p.LogID
                WHERE s.VehicleID = @VehicleID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@VehicleID", _vehicleId)
            };

            // Fetch table using your DatabaseHelper
            DataTable dt = DatabaseHelper.GetTable(query, parameters);
            vehiclehistorygrid.DataSource = dt;

            if (vehiclehistorygrid.Columns["LogID"] != null) vehiclehistorygrid.Columns["LogID"].HeaderText = "Log ID";
            if (vehiclehistorygrid.Columns["Issue"] != null) vehiclehistorygrid.Columns["Issue"].HeaderText = "Issue";
            if (vehiclehistorygrid.Columns["Solution"] != null) vehiclehistorygrid.Columns["Solution"].HeaderText = "Solution";
            if (vehiclehistorygrid.Columns["PartsUsed"] != null) vehiclehistorygrid.Columns["PartsUsed"].HeaderText = "Parts Used";
            if (vehiclehistorygrid.Columns["Status"] != null) vehiclehistorygrid.Columns["Status"].HeaderText = "Status";
            if (vehiclehistorygrid.Columns["LoggedBy"] != null) vehiclehistorygrid.Columns["LoggedBy"].HeaderText = "Logged By";
            if (vehiclehistorygrid.Columns["FixedBy"] != null) vehiclehistorygrid.Columns["FixedBy"].HeaderText = "Fixed By";
            if (vehiclehistorygrid.Columns["DateLogged"] != null) vehiclehistorygrid.Columns["DateLogged"].HeaderText = "Date Logged";
            if (vehiclehistorygrid.Columns["DateFinished"] != null) vehiclehistorygrid.Columns["DateFinished"].HeaderText = "Date Finished";
            if (vehiclehistorygrid.Columns["TotalAmount"] != null) vehiclehistorygrid.Columns["TotalAmount"].HeaderText = "Total Amount";
            if (vehiclehistorygrid.Columns["PaymentDate"] != null) vehiclehistorygrid.Columns["PaymentDate"].HeaderText = "Payment Date";
            if (vehiclehistorygrid.Columns["ProcessedBy"] != null) vehiclehistorygrid.Columns["ProcessedBy"].HeaderText = "Processed By";
        }

        private void SetupHistoryGridStyle()
        {
            vehiclehistorygrid.BackgroundColor = Color.White;
            vehiclehistorygrid.BorderStyle = BorderStyle.None;
            vehiclehistorygrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            vehiclehistorygrid.RowHeadersVisible = false;
            vehiclehistorygrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vehiclehistorygrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vehiclehistorygrid.ReadOnly = true;
            vehiclehistorygrid.AllowUserToAddRows = false;

            vehiclehistorygrid.DefaultCellStyle.Font = new Font("Candara", 10, FontStyle.Regular);
            vehiclehistorygrid.DefaultCellStyle.BackColor = Color.White;
            vehiclehistorygrid.DefaultCellStyle.ForeColor = Color.Black;
            vehiclehistorygrid.DefaultCellStyle.SelectionBackColor = Color.White;
            vehiclehistorygrid.DefaultCellStyle.SelectionForeColor = Color.Black;
            vehiclehistorygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 11, FontStyle.Bold);
            vehiclehistorygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            vehiclehistorygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            vehiclehistorygrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            vehiclehistorygrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            vehiclehistorygrid.EnableHeadersVisualStyles = false;
            vehiclehistorygrid.RowTemplate.Height = 40;
        }
    
        private void ViewVehicleHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
