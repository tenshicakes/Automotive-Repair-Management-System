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
    public partial class vhclEditInfo : Form
    {
        private string _originalPlateNumber;
        private string _originalModel;
        public string UpdatedPlateNumber { get; private set; }
        public vhclEditInfo(string model, string plateNumber)
        {
            InitializeComponent();
            editmodel_txtbox.Text = model;
            editplate_txtbox.Text = plateNumber;

            _originalPlateNumber = plateNumber;
            _originalModel = model;

        }

        private void vhclEditInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string newModel = editmodel_txtbox.Text.Trim();
            string newPlate = editplate_txtbox.Text.Trim();

            if (string.IsNullOrEmpty(newModel) || string.IsNullOrEmpty(newPlate))
            {
                MessageBox.Show("Vehicle Model and Plate Number cannot be empty.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If nothing was changed, close silently and skip the database update
            if (newModel == _originalModel && newPlate == _originalPlateNumber)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                
                if (newPlate != _originalPlateNumber)
                {
                    string checkQuery = "SELECT COUNT(*) FROM VehicleInfo WHERE PlateNumber = @NewPlate";
                    SqlParameter[] checkParams = new SqlParameter[]
                    {
                        new SqlParameter("@NewPlate", newPlate)
                    };

                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                    if (count > 0)
                    {
                        MessageBox.Show("This Plate Number is already registered in the system.", "Duplicate Plate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Execute the update query using DatabaseHelper.ExecuteQuery
                string updateQuery = "UPDATE VehicleInfo SET VehicleModel = @Model, PlateNumber = @NewPlate WHERE PlateNumber = @OriginalPlate";
                SqlParameter[] updateParams = new SqlParameter[]
                {
                    new SqlParameter("@Model", newModel),
                    new SqlParameter("@NewPlate", newPlate),
                    new SqlParameter("@OriginalPlate", _originalPlateNumber)
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(updateQuery, updateParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Vehicle updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.UpdatedPlateNumber = newPlate;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Could not find the original vehicle record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
