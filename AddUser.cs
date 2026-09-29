using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();


            role_combo.DropDownStyle = ComboBoxStyle.DropDownList;
            role_combo.Items.Clear();
            role_combo.Items.AddRange(new string[] { "Administrator", "Owner", "Secretary", "Mechanic" });
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }
        private void addbtn_Click(object sender, EventArgs e)
        {

            string newUsername = username_txtbox.Text.Trim();
            string plainPassword = password_txtbox.Text.Trim();
            string confirmPass = confpass_txtbox.Text.Trim();
            string selectedRole = role_combo.SelectedItem?.ToString() ?? "";


            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(plainPassword) ||
                string.IsNullOrEmpty(confirmPass) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("All fields must be completely filled out.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (plainPassword.Length < 8)
            {
                MessageBox.Show("For security purposes, the password must be at least 8 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (plainPassword != confirmPass)
            {
                MessageBox.Show("The passwords do not match. Please re-type them carefully.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
  
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlParameter[] checkParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", newUsername)
                };

                int duplicateCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                if (duplicateCount > 0)
                {
                    MessageBox.Show("This username is already taken by another account. Please choose a different one.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

           
                string hashedPassword = HashPassword(plainPassword);


                string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@Username", newUsername),
                    new SqlParameter("@Password", hashedPassword),
                    new SqlParameter("@Role", selectedRole)
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(insertQuery, insertParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("New user account successfully created!", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create the new user account. Please try again.", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // SHA256 PASSWORD HASHING 

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}