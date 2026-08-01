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
            // Auto-change/display the labels based on the selected vehicle
            vehiclenamelbl.Text = vehicleModel;
            vehicleplatelbl.Text = plateNumber;
        }

        private void createjoborderbtn_Click(object sender, EventArgs e)
        {
            string loggedBy = loggedby_txtbox.Text.Trim();
            string issue = issue_textbox.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(loggedBy) || string.IsNullOrEmpty(issue))
            {
                MessageBox.Show("Please fill in both the 'Logged by' and 'Issue' fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query to insert into ServiceLogs table
            string query = @"
                INSERT INTO ServiceLogs (VehicleID, LoggedBy, Issue, DateLogged) 
                VALUES (@VehicleID, @LoggedBy, @Issue, GETDATE())";

            SqlParameter[] parameters = {
                new SqlParameter("@VehicleID", _vehicleID),
                new SqlParameter("@LoggedBy", loggedBy),
                new SqlParameter("@Issue", issue)
            };

            try
            {
                // Use your DatabaseHelper ExecuteQuery method for INSERT operations
                int rowsAffected = DatabaseHelper.ExecuteQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Job order created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close the popup form
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
            // Optional: Ask for confirmation if they typed something so they don't accidentally wipe it out
            DialogResult result = MessageBox.Show("Are you sure you want to cancel? Any unsaved changes will be lost.",
                                                  "Confirm Cancel",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Closes the popup form and returns to the main form without touching the database
            }
        }
    }
}
