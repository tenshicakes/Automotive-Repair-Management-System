using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class EditUser : Form
    {

        private int _userID;
        private string _originalUsername;
        private string _originalRole;

        public EditUser(int userId, string username, string password, string role)
        {
            InitializeComponent();
            _userID = userId;
            _originalUsername = username;
            _originalRole = role;

          
            role_combo.Items.Clear();
            role_combo.Items.AddRange(new string[] { "Administrator", "Owner", "Staff", "Mechanic" });
            role_combo.DropDownStyle = ComboBoxStyle.DropDownList;

            username_txtbox.Text = username;
            role_combo.SelectedItem = role;

     
            password_txtbox.Text = "";
            confpass_txtbox.Text = "";
        }

        private void EditUser_Load(object sender, EventArgs e)
        {

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
  
            string newUsername = username_txtbox.Text.Trim();
            string newRole = role_combo.SelectedItem?.ToString() ?? "";
            string newPassword = password_txtbox.Text.Trim();
            string confPassword = confpass_txtbox.Text.Trim();

      
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newRole))
            {
                MessageBox.Show("Username and Role must be filled out.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            bool isChangingPassword = false;
            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confPassword))
            {
                if (newPassword.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters long.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPassword != confPassword)
                {
                    MessageBox.Show("The passwords do not match. Please re-type them.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                isChangingPassword = true;
            }

            if (newUsername == _originalUsername && newRole == _originalRole && !isChangingPassword)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
        
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

            
                string updateQuery;
                List<SqlParameter> updateParams = new List<SqlParameter>
                {
                    new SqlParameter("@Username", newUsername),
                    new SqlParameter("@Role", newRole),
                    new SqlParameter("@UserID", _userID)
                };

             
                if (isChangingPassword)
                {
                    updateQuery = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role WHERE UserID = @UserID";
                    updateParams.Add(new SqlParameter("@Password", HashPassword(newPassword)));
                }
                else
                {
  
                    updateQuery = "UPDATE Users SET Username = @Username, Role = @Role WHERE UserID = @UserID";
                }

                int rowsAffected = DatabaseHelper.ExecuteQuery(updateQuery, updateParams.ToArray());

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