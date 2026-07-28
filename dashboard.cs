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
            RefreshAllGrids();
        }

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // This completely kills the app when the Dashboard is closed
        }


        private FoxButton activeButton = null;
        private void ActiveButton(FoxButton clickedBtn)
        {
            //Set all buttons to inactive by default
            FoxButton[] navbarbuttons = { homebtn, registerbtn, cxbtn, srlogsbtn, accbtn };

            //Default color for all buttons
            foreach (FoxButton button in navbarbuttons)
            {
                button.BaseColor = Color.FromArgb(169, 8, 28);
                button.ForeColor = Color.White;
            }

            //Set a button to active when clicked (color switch)
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
            LoadProductsToIventoryGrid();
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
        }


        private void updatejobbtn_Click(object sender, EventArgs e)
        {
            UpdatePending update = new UpdatePending();
            update.ShowDialog();
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





        private void LoadProductsToIventoryGrid()
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
            // Font and Style for the content cells
            customeraccsgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            customeraccsgrid.DefaultCellStyle.BackColor = Color.White;
            customeraccsgrid.DefaultCellStyle.ForeColor = Color.Black;
            customeraccsgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            customeraccsgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            // Font and Style for the Column Headers
            customeraccsgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            customeraccsgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            customeraccsgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            // Required for custom header background colors to show
            customeraccsgrid.EnableHeadersVisualStyles = false;
            // Height for the rows so they don't look cramped
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
            JobOrder joborder = new JobOrder();
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

            //Customer Details Grid Style
            cxdetailsgrid.BackgroundColor = Color.White;
            cxdetailsgrid.BorderStyle = BorderStyle.None;
            cxdetailsgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            cxdetailsgrid.RowHeadersVisible = false;
            cxdetailsgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cxdetailsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cxdetailsgrid.MultiSelect = true;
            cxdetailsgrid.ReadOnly = true;
            cxdetailsgrid.AllowUserToAddRows = false;
            // Font and Style for the content cells
            cxdetailsgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            cxdetailsgrid.DefaultCellStyle.BackColor = Color.White;
            cxdetailsgrid.DefaultCellStyle.ForeColor = Color.Black;
            cxdetailsgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            cxdetailsgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            // Font and Style for the Column Headers
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            cxdetailsgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            // Required for custom header background colors to show
            cxdetailsgrid.EnableHeadersVisualStyles = false;
            // Height for the rows so they don't look cramped
            cxdetailsgrid.RowTemplate.Height = 40;




            //Vehicle Details Grid Style
            vhclsownedgrid.BackgroundColor = Color.White;
            vhclsownedgrid.BorderStyle = BorderStyle.None;
            vhclsownedgrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            vhclsownedgrid.RowHeadersVisible = false;
            vhclsownedgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vhclsownedgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vhclsownedgrid.MultiSelect = true;
            vhclsownedgrid.ReadOnly = true;
            vhclsownedgrid.AllowUserToAddRows = false;
            // Font and Style for the content cells
            vhclsownedgrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            vhclsownedgrid.DefaultCellStyle.BackColor = Color.White;
            vhclsownedgrid.DefaultCellStyle.ForeColor = Color.Black;
            vhclsownedgrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            vhclsownedgrid.DefaultCellStyle.SelectionForeColor = Color.White;
            // Font and Style for the Column Headers
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            vhclsownedgrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            // Required for custom header background colors to show
            vhclsownedgrid.EnableHeadersVisualStyles = false;
            // Height for the rows so they don't look cramped
            vhclsownedgrid.RowTemplate.Height = 40;
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

        
    }
}
