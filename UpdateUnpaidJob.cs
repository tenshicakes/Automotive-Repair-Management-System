using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Olvarra_Capstone
{
    public partial class UpdateUnpaidJob : Form
    {
        private string _logID;
        private string _partsUsedText;
        private decimal _calculatedTotalAmount = 0;
        public UpdateUnpaidJob(string logID, string partsUsedText)
        {
            InitializeComponent();
            _logID = logID;
            _partsUsedText = partsUsedText;
        }

        private void UpdateUnpaidJob_Load(object sender, EventArgs e)
        {
            CalculateAndDisplayTotal();
            datelbl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void CalculateAndDisplayTotal()
        {
            // If no parts were used, total is 0
            if (string.IsNullOrWhiteSpace(_partsUsedText))
            {
                totalamountlbl.Text = "0.00";
                _calculatedTotalAmount = 0;
                return;
            }

            decimal grandTotal = 0;

            // Parts are formatted like: "Oil Filter (Qty: 3), Air Filter (Qty: 2)"
            // Split by comma to separate each individual part entry
            string[] partEntries = _partsUsedText.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string entry in partEntries)
            {
                // Use RegEx to parse out the part name and quantity
                // Example format: "Oil Filter (Qty: 3)" -> Group 1 = "Oil Filter", Group 2 = "3"
                Match match = Regex.Match(entry.Trim(), @"^(.*?)\s*\(Qty:\s*(\d+)\)$");

                if (match.Success)
                {
                    string partName = match.Groups[1].Value.Trim();
                    int qty = int.Parse(match.Groups[2].Value);

                    // Fetch the price for this specific part from the SpareParts table
                    decimal price = GetPartPriceFromDatabase(partName);

                    // Multiply and add to grand total
                    grandTotal += (price * qty);
                }
            }

            _calculatedTotalAmount = grandTotal;
            totalamountlbl.Text = _calculatedTotalAmount.ToString("N2"); // Formats nicely with commas and 2 decimal places (e.g., "600.00")
        }

        private decimal GetPartPriceFromDatabase(string partName)
        {
            string query = "SELECT Price FROM SpareParts WHERE PartName = @PartName";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PartName", partName)
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);

            // If the part exists, return its price; otherwise default to 0
            if (result != null && decimal.TryParse(result.ToString(), out decimal price))
            {
                return price;
            }

            return 0.00m;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            // 1. Validate Amount Paid textbox
            if (!decimal.TryParse(amountpaid_txtbox.Text.Trim(), out decimal amountPaid) || amountPaid <= 0 || amountpaid_txtbox.Text.Contains("-"))
            {
                MessageBox.Show("Please enter a valid numeric amount paid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                amountpaid_txtbox.Focus();
                return;
            }

            // 2. Validate Processed By textbox
            string processedBy = processby_txtbox.Text.Trim();
            if (string.IsNullOrEmpty(processedBy))
            {
                MessageBox.Show("Please enter who processed the payment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                processby_txtbox.Focus();
                return;
            }

            string paymentDate = datelbl.Text;

            // 3. Prepare Insert Query into PaymentLogs
            // (Mapping LogID ensures this payment is accurately bound to this specific service log)
            string insertQuery = @"
                INSERT INTO PaymentLogs (LogID, TotalAmount, PaymentDate, ProcessedBy) 
                VALUES (@LogID, @TotalAmount, @PaymentDate, @ProcessedBy)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LogID", _logID),
                new SqlParameter("@TotalAmount", amountPaid),
                new SqlParameter("@PaymentDate", paymentDate),
                new SqlParameter("@ProcessedBy", processedBy)
            };

            // 4. Execute insertion using DatabaseHelper
            int rowsAffected = DatabaseHelper.ExecuteQuery(insertQuery, parameters);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Payment recorded successfully! Job order is now marked as paid.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to record payment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    


