using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            /// 1. New Gatekeeper: If locked, do nothing
            if (isLockedOut) return;

            if (string.IsNullOrWhiteSpace(username_txt.Text) || string.IsNullOrWhiteSpace(password_txt.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // The universal connection string for a local .mdf file
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\olvarraDB.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // We ask the database to return the 'Role' if the username AND password match
                    string query = "SELECT Role FROM Users WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // This prevents SQL injection hacks!
                        cmd.Parameters.AddWithValue("@username", username_txt.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", password_txt.Text);

                        // ExecuteScalar grabs the single value we asked for (the Role)
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string userRole = result.ToString();
                            failedAttempts = 0; // Reset attempts on a successful login!

                            MessageBox.Show($"Login Successful! Welcome, {userRole}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Open Dashboard code goes here...
                           

            

                                // Pass the role into the Dashboard
                                dashboard dash = new dashboard(userRole);
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
                                isLockedOut = true; // Set our flag
                                MessageBox.Show($"Too many failed attempts. Please wait {lockoutTime} seconds.", "System Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Visual Lockout
                                username_txt.Enabled = false;
                                password_txt.Enabled = false;

                                // Make the button LOOK disabled without actually disabling it
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
