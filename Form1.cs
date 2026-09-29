using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Olvarra_Capstone
{
    public partial class Form1 : Form
    {
        private int failedAttempts = 0;
        private const int maxAttempts = 3; 
        private int lockoutTime = 30; // 30 seconds lockout
        private Timer lockoutTimer = new Timer();
        private bool isLockedOut = false;
  
        public Form1()
        {
            InitializeComponent();
            lockoutTimer.Interval = 1000; // 1000 milliseconds = 1 second
            lockoutTimer.Tick += LockoutTimer_Tick;
        }


        private void usernamelbl_Click(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void foxLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void foxLabel1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
           
            if (isLockedOut) return;

            string inputUsername = username_txt.Text.Trim();
            string plainPassword = password_txt.Text;

            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(plainPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
         
                string hashedInputPassword = HashPassword(plainPassword);


                string query = "SELECT Role, Username FROM Users WHERE Username = @username AND Password = @password";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", inputUsername),
                    new SqlParameter("@password", hashedInputPassword)
                };


                DataTable result = DatabaseHelper.GetTable(query, parameters);

                if (result.Rows.Count > 0)
                {
                    string userRole = result.Rows[0]["Role"].ToString();
                    string dbUsername = result.Rows[0]["Username"].ToString();
                    failedAttempts = 0; 

                    MessageBox.Show($"Welcome, {userRole}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        
                    dashboard dash = new dashboard(userRole, dbUsername);
                    dash.Show();
                    this.Hide();
                }
                else
                {
                    // INCREASE FAILED ATTEMPTS
                    failedAttempts++;
                    int attemptsLeft = maxAttempts - failedAttempts;

                    if (failedAttempts >= maxAttempts)
                    {
                        isLockedOut = true;
                        MessageBox.Show($"Too many failed attempts. Please wait {lockoutTime} seconds.", "System Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Visual Lockout
                        username_txt.Enabled = false;
                        password_txt.Enabled = false;

                        loginbtn.BaseColor = Color.DimGray;
                        loginbtn.Text = $"Locked ({lockoutTime}s)";

                        lockoutTimer.Start();
                    }
                    else
                    {
                        MessageBox.Show($"Invalid username or password. You have {attemptsLeft} attempts left.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // SHA256 PASSWORD HASHING UTILITY
        // ==========================================
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convert byte to hex string
                }
                return sb.ToString();
            }
        }

        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            lockoutTime--;

            // Force the button to show the new text
            loginbtn.Text = $"Locked ({lockoutTime}s)";
            loginbtn.Refresh();

            if (lockoutTime <= 0)
            {
                lockoutTimer.Stop();
                isLockedOut = false; // Lift the flag

                failedAttempts = 0;
                lockoutTime = 30;

                // Reset UI
                username_txt.Enabled = true;
                password_txt.Enabled = true;
                loginbtn.BaseColor = originalBaseColor; // Return to black
                loginbtn.Text = "Login";

                password_txt.Text = "";
            }
        }

        private void foreverTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dungeonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_BackColorChanged(object sender, EventArgs e)
        {

        }



        private Color originalBaseColor = Color.Black;
        private Color originalTextColor = Color.White;
        private void loginbtn_MouseEnter(object sender, EventArgs e)
        {
            if (isLockedOut) return; // Don't highlight if locked!
            loginbtn.BaseColor = Color.LightGray;

        }

        private void loginbtn_MouseLeave(object sender, EventArgs e)
        {
            if (isLockedOut)
            {
                loginbtn.BaseColor = Color.DimGray; // Stay gray if locked
                return;
            }
            loginbtn.BaseColor = originalBaseColor;
        }

        private void loginbtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (isLockedOut) return;
            loginbtn.BaseColor = Color.FromArgb(194, 0, 0);
        }

        private void loginbtn_MouseUp(object sender, MouseEventArgs e)
        {
            if (isLockedOut)
            {
                // Keep it Gray if we are still in lockout mode
                loginbtn.BaseColor = Color.DimGray;
                return;
            }

            loginbtn.BaseColor = originalBaseColor;
        }

        private void username_txt_Click(object sender, EventArgs e)
        {

        }

        private void password_txt_Click(object sender, EventArgs e)
        {

        }

        private void username_txt_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void leftpanel_Paint(object sender, PaintEventArgs e)
        {
            Color color1 = Color.FromArgb(113, 107, 109); 
            Color color2 = Color.FromArgb(28, 28, 28); 

            // Create the brush. LinearGradientMode.Vertical makes it fade top-to-bottom.
            using (LinearGradientBrush brush = new LinearGradientBrush(this.leftpanel.ClientRectangle, color1, color2, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.leftpanel.ClientRectangle);
            }
        }

        private void loginform_Click(object sender, EventArgs e)
        {

        }
    }
}
