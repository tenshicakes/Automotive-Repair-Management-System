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
    public partial class AddVehicle : Form
    {
        private int _customerID;

        // Property to pass the newly created plate number back to the dashboard
        public string NewPlateNumber { get; private set; }
        public AddVehicle(int customerId)
        {
            InitializeComponent();
            _customerID = customerId;
        }

        private void AddVehicle_Load(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            // Sanitize inputs to prevent blank spaces from being inserted
            string newModel = model_txtbox.Text.Trim();
            string newPlate = platenum_txtbox.Text.Trim();

            // 1. Validation: Prevent empty submissions
            if (string.IsNullOrEmpty(newModel) || string.IsNullOrEmpty(newPlate))
            {
                MessageBox.Show("Please fill out both the Vehicle Model and Plate Number.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Validation: Check for duplicate plate numbers system-wide
                string checkQuery = "SELECT COUNT(*) FROM VehicleInfo WHERE PlateNumber = @PlateNumber";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@PlateNumber", newPlate)
                };

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                if (count > 0)
                {
                    MessageBox.Show("This Plate Number is already registered in the system.", "Duplicate Plate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Execution: Insert the new vehicle linked to the CustomerID
                string insertQuery = @"
                    INSERT INTO VehicleInfo (CustomerID, VehicleModel, PlateNumber) 
                    VALUES (@CustomerID, @Model, @PlateNumber)";

                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID", _customerID),
                    new SqlParameter("@Model", newModel),
                    new SqlParameter("@PlateNumber", newPlate)
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(insertQuery, insertParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("New vehicle added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Store the plate so the dashboard can auto-search it, then close
                    this.NewPlateNumber = newPlate;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add the vehicle. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
