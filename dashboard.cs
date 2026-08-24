using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinPanel = System.Windows.Forms.Panel;

namespace Olvarra_Capstone
{
    public partial class dashboard : Form
    {
        public string currentUserRole = "";
        public dashboard(string role)
        {
            InitializeComponent();
            currentUserRole = role;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
                ActiveButton(homebtn);
            ShowPanel(homecontainer);

            LoadPendingJobOrdersToGrid();
            SetupPendingJobOrdersGridStyle();

            LoadProductsToInventoryGrid();
            SetupInventoryGridStyle();

            RefreshAllGrids();
        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); 
        }


        private FoxButton activeButton = null;
        private void ActiveButton(FoxButton clickedBtn)
        {
            
            FoxButton[] navbarbuttons = { homebtn, registerbtn, cxbtn, srlogsbtn, accbtn };

            
            foreach (FoxButton button in navbarbuttons)
            {
                button.BaseColor = Color.FromArgb(169, 8, 28);
                button.ForeColor = Color.White;
            }

            
            clickedBtn.BaseColor = Color.White;
            clickedBtn.ForeColor = Color.FromArgb(169, 8, 28);

            activeButton = clickedBtn;

        }

        private void ShowPanel(WinPanel paneltoshow)
        {
            WinPanel[] panels = { accscontainer, homecontainer, rgstrcontainer, cstmrscontainer, srvclgscontainer };

            foreach (WinPanel panel in panels)
            {
                panel.Visible = false;
            }

            paneltoshow.Visible = true;
        }







        private void RefreshAllGrids()
        {
            LoadPendingJobOrdersToGrid();
            SetupPendingJobOrdersGridStyle();

            LoadProductsToInventoryGrid();
            SetupInventoryGridStyle();

            LoadCustomerAccsToGrid();
            SetupCustomerAccsGridStyle();

            SetupCustomerAndVehicleDetailGridStyle();

            
        }
















        //====================== HOME BUTTON ================ HOME BUTTON ==================== HOME BUTTON ==================
        private void foxButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(homebtn);
            ShowPanel(homecontainer);
            LoadPendingJobOrdersToGrid();
            SetupPendingJobOrdersGridStyle();
            LoadProductsToInventoryGrid();
            SetupInventoryGridStyle();
            RefreshAllGrids();
        }



        
        private void LoadPendingJobOrdersToGrid()
        {
            string query = "SELECT s.LogID, v.VehicleModel, v.PlateNumber, s.Issue, s.LoggedBy, s.DateLogged FROM VehicleInfo v INNER JOIN ServiceLogs s ON v.VehicleID = s.VehicleID WHERE s.Status = 'Pending'";
            DataTable dt = DatabaseHelper.GetTable(query);
            pendingjobgrid.DataSource = dt;
            pendingjobgrid.Columns["VehicleModel"].HeaderText = "Vehicle Model";
            pendingjobgrid.Columns["PlateNumber"].HeaderText = "Plate Number";
            pendingjobgrid.Columns["Issue"].HeaderText = "Issue";
            pendingjobgrid.Columns["LoggedBy"].HeaderText = "Logged By";
            pendingjobgrid.Columns["DateLogged"].HeaderText = "Date Logged";
            
        }

        private void SetupPendingJobOrdersGridStyle()
        {
            pendingjobgrid.BackgroundColor = Color.White;
            pendingjobgrid.BorderStyle = BorderStyle.None;
            pendingjobgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            pendingjobgrid.RowHeadersVisible = false;
            pendingjobgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pendingjobgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            pendingjobgrid.ReadOnly = true;
            pendingjobgrid.AllowUserToAddRows = false;
            
            pendingjobgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            pendingjobgrid.DefaultCellStyle.BackColor = Color.White;
            pendingjobgrid.DefaultCellStyle.ForeColor = Color.Black;
            pendingjobgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            pendingjobgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            
            pendingjobgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            pendingjobgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            pendingjobgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            pendingjobgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            pendingjobgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            pendingjobgrid.EnableHeadersVisualStyles = false;
            pendingjobgrid.RowTemplate.Height = 40;
        }

        private void updatejobbtn_Click(object sender, EventArgs e)
        {
            if (pendingjobgrid.SelectedRows.Count == 0 && pendingjobgrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a pending job order first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = pendingjobgrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = pendingjobgrid.Rows[rowIndex];
            string serviceLogID = selectedRow.Cells["LogID"].Value.ToString();
            string vehicleModel = selectedRow.Cells["VehicleModel"].Value.ToString();
            string plateNumber = selectedRow.Cells["PlateNumber"].Value.ToString();

            UpdatePending updateForm = new UpdatePending(serviceLogID, vehicleModel, plateNumber);
            updateForm.ShowDialog();
            
            RefreshAllGrids();
        }
        private void viewunpaidjob_Click(object sender, EventArgs e)
        {
            UnpaidJob unpaidJob = new UnpaidJob();
            unpaidJob.ShowDialog();
        }

        private void viewfinishjob_Click(object sender, EventArgs e)
        {
            FinishedJob finishedjob = new FinishedJob();
            finishedjob.ShowDialog();
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




        //====================== REGISTER BUTTON ================ REGISTER BUTTON ==================== REGISTER BUTTON ==================
        private void registerbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(registerbtn);
            ShowPanel(rgstrcontainer);
        }


        private void registervhctn_Click(object sender, EventArgs e)
        {
            string fullName = fname_txtbox.Text.Trim();
            string phone = phonenum_txtbox.Text.Trim();
            string address = address_txtbox.Text.Trim();
            string vehicleModel = vhclmodel_txtbox.Text.Trim();
            string plateNumber = platenum_txtbox.Text.Trim();

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(vehicleModel) || string.IsNullOrEmpty(plateNumber))
            {
                MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string combinedQuery = @"
        BEGIN TRY
            BEGIN TRANSACTION;

            DECLARE @NewCustomerID INT;

            INSERT INTO CustomerInfo (FullName, PhoneNumber, Address) 
            VALUES (@FullName, @PhoneNumber, @Address);

            SET @NewCustomerID = SCOPE_IDENTITY();

            INSERT INTO VehicleInfo (CustomerID, VehicleModel, PlateNumber) 
            VALUES (@NewCustomerID, @VehicleModel, @PlateNumber);

            COMMIT TRANSACTION;
        END TRY
        BEGIN CATCH
            ROLLBACK TRANSACTION;
            THROW;
        END CATCH";

            SqlParameter[] parameters = {
        new SqlParameter("@FullName", fullName),
        new SqlParameter("@PhoneNumber", phone),
        new SqlParameter("@Address", address),
        new SqlParameter("@VehicleModel", vehicleModel),
        new SqlParameter("@PlateNumber", plateNumber)
    };

            try
            {
                int rowsAffected = DatabaseHelper.ExecuteQuery(combinedQuery, parameters);

                MessageBox.Show("Customer and vehicle registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAllForms();
            }
            catch (Exception ex)
            {
                // Catch duplicate plate number or any other database error cleanly
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint") || ex.Message.Contains("PlateNumber"))
                {
                    MessageBox.Show("This plate number is already registered in the system.", "Duplicate Plate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearAllForms()
        {
         
            fname_txtbox.Text = "";
            phonenum_txtbox.Text = "";
            address_txtbox.Text = "";
            vhclmodel_txtbox.Text = "";
            platenum_txtbox.Text = "";
        }












        //====================== CUSTOMER BUTTON ================ CUSTOMER BUTTON ==================== CUSTOMER BUTTON ==================
        private void cxbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(cxbtn);
            ShowPanel(cstmrscontainer);
            LoadCustomerAccsToGrid();
            SetupCustomerAccsGridStyle();
        }


        private void LoadCustomerAccsToGrid()
            {
            string query = "SELECT CustomerID, FullName, PhoneNumber, Address FROM CustomerInfo";
            DataTable dt = DatabaseHelper.GetTable(query);
            customeraccsgrid.DataSource = dt;
            customeraccsgrid.Columns["CustomerID"].HeaderText = "Customer ID";
            customeraccsgrid.Columns["FullName"].HeaderText = "Full Name";
            customeraccsgrid.Columns["PhoneNumber"].HeaderText = "Phone Number";
            customeraccsgrid.Columns["Address"].HeaderText = "Address";
        }

        private void SetupCustomerAccsGridStyle()
        {
            customeraccsgrid.BackgroundColor = Color.White;
            customeraccsgrid.BorderStyle = BorderStyle.None;
            customeraccsgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            customeraccsgrid.RowHeadersVisible = false;
            customeraccsgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customeraccsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customeraccsgrid.MultiSelect = true;
            customeraccsgrid.ReadOnly = true;
            customeraccsgrid.AllowUserToAddRows = false;
            customeraccsgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            customeraccsgrid.DefaultCellStyle.BackColor = Color.White;
            customeraccsgrid.DefaultCellStyle.ForeColor = Color.Black;
            customeraccsgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            customeraccsgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            customeraccsgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            customeraccsgrid.EnableHeadersVisualStyles = false;
            customeraccsgrid.RowTemplate.Height = 40;
        }


        private void cxsearchbtn_Click(object sender, EventArgs e)
        {

        }





        //====================== SRVC LOGS BUTTON ================ SRVC LOGS BUTTON ==================== SRVC LOGS BUTTON ==================
        private void srlogsbtn_Click(object sender, EventArgs e) 
        {
            ActiveButton(srlogsbtn);
            ShowPanel(srvclgscontainer);
        }


        //======================
        //EDIT CUSTOMER INFO BUTTON
        //======================
        private void foxButton2_Click(object sender, EventArgs e)
        {
            cxEditInfo cxinfo = new cxEditInfo();
            cxinfo.ShowDialog();
        }


        //======================
        //EDIT VEHICLE INFO BUTTON
        //======================
        private void vhcleditinfo_Click(object sender, EventArgs e)
        {
            vhclEditInfo vhclinfo = new vhclEditInfo();
            vhclinfo.ShowDialog();
        }

        //=======================
        //NEW JOB ORDER BUTTON
        //=======================
        private void foxButton2_Click_1(object sender, EventArgs e)
        {
            
            if (vhclsownedgrid.SelectedRows.Count == 0 && vhclsownedgrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a vehicle row first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected row (handles full row select or cell select)
            int rowIndex = vhclsownedgrid.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = vhclsownedgrid.Rows[rowIndex];

            // Extract the needed data (Make sure your column names match your database/grid columns)
            string vehicleID = selectedRow.Cells["VehicleID"].Value.ToString();
            string vehicleModel = selectedRow.Cells["VehicleModel"].Value.ToString();
            string plateNumber = selectedRow.Cells["PlateNumber"].Value.ToString();

            // Open the popup form and pass the data
  
            JobOrder joborder = new JobOrder(vehicleID, vehicleModel, plateNumber);
            joborder.ShowDialog();
        }

        //=======================
        //ADD VEHICLE BUTTON
        //=======================
        private void addvehiclebtn_Click(object sender, EventArgs e)
        {
            AddVehicle addvhcl = new AddVehicle();
            addvhcl.ShowDialog();
        }


        //======================
        //SEARCH BUTTON
        //======================
        private void searchbtn_Click(object sender, EventArgs e)
        {
            string plateNumberToSearch = search_txtbox.Text.Trim();

            if (string.IsNullOrEmpty(plateNumberToSearch))
            {
                MessageBox.Show("Please enter a plate number to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerQuery = @"
            SELECT c.CustomerID, c.FullName, c.PhoneNumber, c.Address
            FROM CustomerInfo c
            INNER JOIN VehicleInfo v ON c.CustomerID = v.CustomerID
            WHERE v.PlateNumber = @PlateNumber";

            string vehicleQuery = @"
            SELECT VehicleID, CustomerID, VehicleModel, PlateNumber
            FROM VehicleInfo
            WHERE PlateNumber = @PlateNumber";


            SqlParameter[] parameters = {
            new SqlParameter("@PlateNumber", plateNumberToSearch)
            };

            DataTable dtCustomer = DatabaseHelper.GetTable(customerQuery, parameters);
            DataTable dtVehicle = DatabaseHelper.GetTable(vehicleQuery, parameters);

            cxdetailsgrid.DataSource = dtCustomer;
            vhclsownedgrid.DataSource = dtVehicle;
            SetupCustomerAndVehicleDetailGridStyle();

            if (dtCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No records found for that plate number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


       private void SetupCustomerAndVehicleDetailGridStyle ()
        {
            cxdetailsgrid.BackgroundColor = Color.White;
            cxdetailsgrid.BorderStyle = BorderStyle.None;
            cxdetailsgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            cxdetailsgrid.RowHeadersVisible = false;
            cxdetailsgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cxdetailsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cxdetailsgrid.MultiSelect = true;
            cxdetailsgrid.ReadOnly = true;
            cxdetailsgrid.AllowUserToAddRows = false;
            cxdetailsgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            cxdetailsgrid.DefaultCellStyle.BackColor = Color.White;
            cxdetailsgrid.DefaultCellStyle.ForeColor = Color.Black;
            cxdetailsgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            cxdetailsgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            cxdetailsgrid.EnableHeadersVisualStyles = false;
            cxdetailsgrid.RowTemplate.Height = 40;


            vhclsownedgrid.BackgroundColor = Color.White;
            vhclsownedgrid.BorderStyle = BorderStyle.None;
            vhclsownedgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            vhclsownedgrid.RowHeadersVisible = false;
            vhclsownedgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vhclsownedgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vhclsownedgrid.MultiSelect = true;
            vhclsownedgrid.ReadOnly = true;
            vhclsownedgrid.AllowUserToAddRows = false;
            vhclsownedgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            vhclsownedgrid.DefaultCellStyle.BackColor = Color.White;
            vhclsownedgrid.DefaultCellStyle.ForeColor = Color.Black;
            vhclsownedgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            vhclsownedgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            vhclsownedgrid.EnableHeadersVisualStyles = false;
            vhclsownedgrid.RowTemplate.Height = 40;
        }



        private void vhclsownedgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure they clicked an actual row and not the header
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = vhclsownedgrid.Rows[e.RowIndex];

                // Grab the necessary data from the clicked row 
                // (Make sure these column names match your vhclsownedgrid's data source columns)
                int vehicleId = Convert.ToInt32(row.Cells["VehicleID"].Value);
                string vehicleModel = row.Cells["VehicleModel"].Value.ToString();
                string plateNumber = row.Cells["PlateNumber"].Value.ToString();

                // Open the ViewVehicleHistory form and pass the data into its constructor
                ViewVehicleHistory historyForm = new ViewVehicleHistory(vehicleId, vehicleModel, plateNumber);
                historyForm.ShowDialog();
            }
        }












        //====================== ACCOUNTS BUTTON ================ ACCOUNTS BUTTON ==================== ACCOUNTS BUTTON ==================
        private void accbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(accbtn);
            ShowPanel(accscontainer);
        }

























        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dungeonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        

        private void rgstrcontainer_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dungeonTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void rgstrnewcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rgstrvhclcancelbtn_Click(object sender, EventArgs e)
        {

        }

        private void foxLabel3_Click(object sender, EventArgs e)
        {

        }

        private void foxBigLabel8_Click(object sender, EventArgs e)
        {

        }

        private void searchresultscontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void rgstrnewlabel_Click(object sender, EventArgs e)
        {

        }

        private void vhclsownedgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
