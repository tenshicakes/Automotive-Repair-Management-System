namespace Olvarra_Capstone
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.loginform = new ReaLTaiizor.Forms.AirForm();
            this.rightpanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.password_txt = new ReaLTaiizor.Controls.DungeonTextBox();
            this.username_txt = new ReaLTaiizor.Controls.DungeonTextBox();
            this.loginbtn = new ReaLTaiizor.Controls.ForeverButton();
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.usernamelbl = new ReaLTaiizor.Controls.FoxLabel();
            this.loginform.SuspendLayout();
            this.rightpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginform
            // 
            this.loginform.BackColor = System.Drawing.Color.White;
            this.loginform.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.loginform.Controls.Add(this.rightpanel);
            this.loginform.Controls.Add(this.leftpanel);
            this.loginform.Customization = "AAAA/1paWv9ycnL/";
            this.loginform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginform.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.loginform.Image = null;
            this.loginform.Location = new System.Drawing.Point(0, 0);
            this.loginform.MaximumSize = new System.Drawing.Size(800, 450);
            this.loginform.MinimumSize = new System.Drawing.Size(800, 450);
            this.loginform.Movable = true;
            this.loginform.Name = "loginform";
            this.loginform.NoRounding = false;
            this.loginform.Sizable = true;
            this.loginform.Size = new System.Drawing.Size(800, 450);
            this.loginform.SmartBounds = true;
            this.loginform.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.loginform.TabIndex = 0;
            this.loginform.Text = "Login";
            this.loginform.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.loginform.Transparent = false;
            // 
            // rightpanel
            // 
            this.rightpanel.BackColor = System.Drawing.Color.Transparent;
            this.rightpanel.Controls.Add(this.pictureBox1);
            this.rightpanel.Location = new System.Drawing.Point(447, 24);
            this.rightpanel.Name = "rightpanel";
            this.rightpanel.Size = new System.Drawing.Size(353, 426);
            this.rightpanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 278);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // leftpanel
            // 
            this.leftpanel.BackColor = System.Drawing.Color.White;
            this.leftpanel.Controls.Add(this.password_txt);
            this.leftpanel.Controls.Add(this.username_txt);
            this.leftpanel.Controls.Add(this.loginbtn);
            this.leftpanel.Controls.Add(this.foxLabel1);
            this.leftpanel.Controls.Add(this.usernamelbl);
            this.leftpanel.Location = new System.Drawing.Point(0, 24);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(449, 426);
            this.leftpanel.TabIndex = 0;
            this.leftpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.leftpanel_Paint);
            // 
            // password_txt
            // 
            this.password_txt.BackColor = System.Drawing.Color.Transparent;
            this.password_txt.BorderColor = System.Drawing.Color.Transparent;
            this.password_txt.EdgeColor = System.Drawing.Color.Transparent;
            this.password_txt.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_txt.ForeColor = System.Drawing.Color.Black;
            this.password_txt.Location = new System.Drawing.Point(92, 206);
            this.password_txt.MaxLength = 32767;
            this.password_txt.Multiline = false;
            this.password_txt.Name = "password_txt";
            this.password_txt.ReadOnly = false;
            this.password_txt.Size = new System.Drawing.Size(261, 36);
            this.password_txt.TabIndex = 10;
            this.password_txt.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.password_txt.UseSystemPasswordChar = true;
            // 
            // username_txt
            // 
            this.username_txt.BackColor = System.Drawing.Color.Transparent;
            this.username_txt.BorderColor = System.Drawing.Color.Transparent;
            this.username_txt.EdgeColor = System.Drawing.Color.Transparent;
            this.username_txt.Font = new System.Drawing.Font("Candara Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txt.ForeColor = System.Drawing.Color.Black;
            this.username_txt.Location = new System.Drawing.Point(92, 128);
            this.username_txt.MaxLength = 32767;
            this.username_txt.Multiline = false;
            this.username_txt.Name = "username_txt";
            this.username_txt.ReadOnly = false;
            this.username_txt.Size = new System.Drawing.Size(261, 36);
            this.username_txt.TabIndex = 9;
            this.username_txt.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.username_txt.UseSystemPasswordChar = false;
            this.username_txt.TextChanged += new System.EventHandler(this.username_txt_TextChanged_1);
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.Transparent;
            this.loginbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.loginbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.Transparent;
            this.loginbtn.Location = new System.Drawing.Point(151, 317);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Rounded = true;
            this.loginbtn.Size = new System.Drawing.Size(157, 50);
            this.loginbtn.TabIndex = 6;
            this.loginbtn.Text = "Login";
            this.loginbtn.TextColor = System.Drawing.Color.White;
            this.loginbtn.BackColorChanged += new System.EventHandler(this.loginbtn_BackColorChanged);
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            this.loginbtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.loginbtn_MouseDown);
            this.loginbtn.MouseEnter += new System.EventHandler(this.loginbtn_MouseEnter);
            this.loginbtn.MouseLeave += new System.EventHandler(this.loginbtn_MouseLeave);
            this.loginbtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.loginbtn_MouseUp);
            // 
            // foxLabel1
            // 
            this.foxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel1.ForeColor = System.Drawing.Color.White;
            this.foxLabel1.Location = new System.Drawing.Point(92, 172);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(105, 28);
            this.foxLabel1.TabIndex = 4;
            this.foxLabel1.Text = "Password";
            this.foxLabel1.Click += new System.EventHandler(this.foxLabel1_Click);
            // 
            // usernamelbl
            // 
            this.usernamelbl.BackColor = System.Drawing.Color.Transparent;
            this.usernamelbl.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernamelbl.ForeColor = System.Drawing.Color.White;
            this.usernamelbl.Location = new System.Drawing.Point(92, 92);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(105, 30);
            this.usernamelbl.TabIndex = 3;
            this.usernamelbl.Text = "Username";
            this.usernamelbl.Click += new System.EventHandler(this.usernamelbl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.loginform.ResumeLayout(false);
            this.rightpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftpanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.AirForm loginform;
        private System.Windows.Forms.Panel leftpanel;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel usernamelbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel rightpanel;
        private ReaLTaiizor.Controls.ForeverButton loginbtn;
        private ReaLTaiizor.Controls.DungeonTextBox username_txt;
        private ReaLTaiizor.Controls.DungeonTextBox password_txt;
    }
}

