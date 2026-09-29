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
    public partial class JobOrder : Form
    {
        public string _vehicleID;
        public JobOrder(string vehicleID, string vehicleModel, string plateNumber)
        {
            InitializeComponent();
            _vehicleID = vehicleID;
            vehiclenamelbl.Text = vehicleModel;
            vehicleplatelbl.Text = plateNumber;
        }

        private void createjoborderbtn_Click(object sender, EventArgs e)
        {
            string loggedBy = loggedby_txtbox.Text.Trim();
            string issue = issue_textbox.Text.Trim();
            string status = statuslbl.Text.Trim();

          
            if (string.IsNullOrEmpty(loggedBy) || string.IsNullOrEmpty(issue))
            {
                MessageBox.Show("Please fill in both the 'Logged by' and 'Issue' fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
                INSERT INTO ServiceLogs (VehicleID, LoggedBy, Issue, Status, DateLogged) 
                VALUES (@VehicleID, @LoggedBy, @Issue, @Status, GETDATE())";

            SqlParameter[] parameters = {
                new SqlParameter("@VehicleID", _vehicleID),
                new SqlParameter("@LoggedBy", loggedBy),
                new SqlParameter("@Issue", issue),
                new SqlParameter("@Status", status)
            };

            try
            {
       
                int rowsAffected = DatabaseHelper.ExecuteQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Job order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Failed to create job order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void JobOrder_Load(object sender, EventArgs e)
        {

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                                                  "Confirm Cancel",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); 
            }
        }
    }
}
