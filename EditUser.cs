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
    public partial class EditUser : Form
    {
        // Track the unique identifier and original values to detect real changes
        private int _userID;
        private string _originalUsername;
        private string _originalPassword;
        private string _originalRole;
        public EditUser(int userId, string username, string password, string role)
        {
            InitializeComponent();
            _userID = userId;
            _originalUsername = username;
            _originalPassword = password;
            _originalRole = role;

            // Load the dropdown options programmatically to prevent typos
            role_combo.Items.Clear();
            role_combo.Items.AddRange(new string[] { "Administrator", "Owner", "Staff", "Mechanic" });
            role_combo.DropDownStyle = ComboBoxStyle.DropDownList; // Prevents typing custom roles

            // Pre-fill the controls
            username_txtbox.Text = username;
            password_txtbox.Text = password;
            confpass_txtbox.Text = password;
            role_combo.SelectedItem = role;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            // Sanitize inputs
            string newUsername = username_txtbox.Text.Trim();
            string newPassword = password_txtbox.Text.Trim();
            string confPassword = confpass_txtbox.Text.Trim();
            string newRole = role_combo.SelectedItem?.ToString() ?? "";

            // No blanks
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confPassword) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("All fields must be filled out.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password Length
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password Match
            if (newPassword != confPassword)
            {
                MessageBox.Show("The passwords do not match. Please re-type them.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if anything actually changed
            if (newUsername == _originalUsername && newPassword == _originalPassword && newRole == _originalRole)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                // Check for Duplicate Usernames (excluding the current user)
                if (newUsername != _originalUsername)
                {
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND UserID != @UserID";
                    SqlParameter[] checkParams = {
                        new SqlParameter("@Username", newUsername),
                        new SqlParameter("@UserID", _userID)
                    };

                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
                    if (count > 0)
                    {
                        MessageBox.Show("This username is already taken by another account. Please choose a different one.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 6. Execute Update
                string updateQuery = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";
                SqlParameter[] updateParams = {
                    new SqlParameter("@Username", newUsername),
                    new SqlParameter("@Password", newPassword),
                    new SqlParameter("@Role", newRole),
                    new SqlParameter("@UserID", _userID)
                };

                int rowsAffected = DatabaseHelper.ExecuteQuery(updateQuery, updateParams);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. Could not find the original user record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
