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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            
            stocks_txtbox.KeyPress += Stocks_txtbox_KeyPress;
            price_txtbox.KeyPress += Price_txtbox_KeyPress;
        }

        private void Stocks_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only control keys (like backspace) and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Price_txtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys, digits, and exactly one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Prevent a second decimal point from being typed
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string partName = name_txtbox.Text.Trim();
            string stocksStr = stocks_txtbox.Text.Trim();
            string priceStr = price_txtbox.Text.Trim();

            // 1. Check for empty fields
            if (string.IsNullOrEmpty(partName) || string.IsNullOrEmpty(stocksStr) || string.IsNullOrEmpty(priceStr))
            {
                MessageBox.Show("All fields must be filled out before adding a new product.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Parse values (Safeguard against copy-pasting invalid characters)
            if (!int.TryParse(stocksStr, out int stocks))
            {
                MessageBox.Show("Invalid stock quantity. Please enter a valid whole number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(priceStr, out decimal price))
            {
                MessageBox.Show("Invalid price format. Please enter a valid number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 3. Check for duplicates
                string checkQuery = "SELECT COUNT(*) FROM SpareParts WHERE PartName = @PartName";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@PartName", partName)
                };

                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                if (count > 0)
                {
                    MessageBox.Show("This part already exists in the inventory.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Insert the new part
                string insertQuery = "INSERT INTO SpareParts (PartName, StockQuantity, Price) VALUES (@PartName, @StockQuantity, @Price)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@PartName", partName),
                    new SqlParameter("@StockQuantity", stocks),
                    new SqlParameter("@Price", price)
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(insertQuery, insertParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("New product successfully added to inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Triggers UI reload in EditInventory.cs
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add the new product. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
