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

            // Font and Style for the content cells
            inventorygrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            inventorygrid.DefaultCellStyle.BackColor = Color.White;
            inventorygrid.DefaultCellStyle.ForeColor = Color.Black;
            inventorygrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            inventorygrid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Font and Style for the Column Headers
            inventorygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            inventorygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            inventorygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            inventorygrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            inventorygrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Required for custom header background colors to show
            inventorygrid.EnableHeadersVisualStyles = false;

            // Height for the rows so they don't look cramped
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



        //=====================================================================
        //POTENTIONAL QUERY FOR SEARCHING CUSTOMERS INFO BASED ON PLATE NUMBER
        //=========== ==========================================================

        /* 
         * private void searchbtn_Click(object sender, EventArgs e)
{ 
    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryDB.mdf;Integrated Security=True";

    string query = @"
    SELECT
        c.FullName,
        c.PhoneNumber,
        c.Address,
        v.VehicleModel,
        v.PlateNumber 
    FROM CustomerInfo c
    INNER JOIN VehicleInfo v
        ON c.CustomerID = v.CustomerID
    WHERE v.PlateNumber = @PlateNumber";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@PlateNumber", search_txtbox.Text.Trim());

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                FoxBigLabel1.Text = reader["FullName"].ToString();
                FoxBigLabel2.Text = reader["PhoneNumber"].ToString();
                FoxBigLabel3.Text = reader["Address"].ToString();
                FoxBigLabel4.Text = reader["VehicleModel"].ToString();
                FoxBigLabel5.Text = reader["PlateNumber"].ToString();
            }
            else
            {
                MessageBox.Show("Plate number not found.");

                FoxBigLabel1.Text = "";
                FoxBigLabel2.Text = "";
                FoxBigLabel3.Text = "";
                FoxBigLabel4.Text = "";
                FoxBigLabel5.Text = "";
            }
        }
    }
}

        */















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
