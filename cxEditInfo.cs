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
    public partial class cxEditInfo : Form
    {
        private int _customerID;
        private string _originalName;
        private string _originalPhone;
        private string _originalAddress;
        public cxEditInfo(int customerId, string name, string phone, string address)
        {
            InitializeComponent();
            _customerID = customerId;

            // Lock in original values for comparison
            _originalName = name;
            _originalPhone = phone;
            _originalAddress = address;

            // Populate the textboxes
            editname_txtbox.Text = name;
            editphone_txtbox.Text = phone;
            editaddress_txtbox.Text = address;
            
        }

        private void cxEditInfo_Load(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
           
            string newName = editname_txtbox.Text.Trim();
            string newPhone = editphone_txtbox.Text.Trim();
            string newAddress = editaddress_txtbox.Text.Trim();

           
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPhone) || string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("All fields (Name, Phone Number, and Address) must be filled out.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (newName == _originalName && newPhone == _originalPhone && newAddress == _originalAddress)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                
                string updateQuery = @"
                    UPDATE CustomerInfo 
                    SET FullName = @Name, PhoneNumber = @Phone, Address = @Address 
                    WHERE CustomerID = @CustomerID";

                SqlParameter[] updateParams = new SqlParameter[]
                {
                    new SqlParameter("@Name", newName),
                    new SqlParameter("@Phone", newPhone),
                    new SqlParameter("@Address", newAddress),
                    new SqlParameter("@CustomerID", _customerID) 
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(updateQuery, updateParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Triggers UI reload in dashboard
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Could not find the original customer record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

