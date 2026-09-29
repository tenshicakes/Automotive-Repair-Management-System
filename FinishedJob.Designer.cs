namespace Olvarra_Capstone
{
    partial class FinishedJob
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
            this.MaterialCard = new ReaLTaiizor.Controls.MaterialCard();
            this.finishedjobgrid = new System.Windows.Forms.DataGridView();
            this.foxbutton = new ReaLTaiizor.Controls.FoxLabel();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.reportbtn = new ReaLTaiizor.Controls.FoxButton();
            this.MaterialCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finishedjobgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MaterialCard
            // 
            this.MaterialCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MaterialCard.Controls.Add(this.finishedjobgrid);
            this.MaterialCard.Depth = 0;
            this.MaterialCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MaterialCard.Location = new System.Drawing.Point(36, 98);
            this.MaterialCard.Margin = new System.Windows.Forms.Padding(14);
            this.MaterialCard.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.MaterialCard.Name = "MaterialCard";
            this.MaterialCard.Padding = new System.Windows.Forms.Padding(14);
            this.MaterialCard.Size = new System.Drawing.Size(816, 336);
            this.MaterialCard.TabIndex = 2;
            this.MaterialCard.Paint += new System.Windows.Forms.PaintEventHandler(this.finishedjobgrid_Paint);
            // 
            // finishedjobgrid
            // 
            this.finishedjobgrid.AllowUserToAddRows = false;
            this.finishedjobgrid.AllowUserToDeleteRows = false;
            this.finishedjobgrid.AllowUserToResizeColumns = false;
            this.finishedjobgrid.AllowUserToResizeRows = false;
            this.finishedjobgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.finishedjobgrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.finishedjobgrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.finishedjobgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.finishedjobgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishedjobgrid.Location = new System.Drawing.Point(14, 14);
            this.finishedjobgrid.MultiSelect = false;
            this.finishedjobgrid.Name = "finishedjobgrid";
            this.finishedjobgrid.ReadOnly = true;
            this.finishedjobgrid.RowHeadersVisible = false;
            this.finishedjobgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.finishedjobgrid.Size = new System.Drawing.Size(788, 308);
            this.finishedjobgrid.TabIndex = 11;
            this.finishedjobgrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.finishedjobgrid_CellContentClick);
            // 
            // foxbutton
            // 
            this.foxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxbutton.BackColor = System.Drawing.Color.Transparent;
            this.foxbutton.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxbutton.ForeColor = System.Drawing.Color.White;
            this.foxbutton.Location = new System.Drawing.Point(36, 12);
            this.foxbutton.Name = "foxbutton";
            this.foxbutton.Size = new System.Drawing.Size(265, 23);
            this.foxbutton.TabIndex = 9;
            this.foxbutton.Text = "Job Orders that are finished ";
            this.foxbutton.Click += new System.EventHandler(this.foxbutton_Click);
            // 
            // dtpfrom
            // 
            this.dtpfrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpfrom.Checked = false;
            this.dtpfrom.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(437, 61);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.ShowCheckBox = true;
            this.dtpfrom.Size = new System.Drawing.Size(200, 31);
            this.dtpfrom.TabIndex = 10;
            this.dtpfrom.ValueChanged += new System.EventHandler(this.dtpfrom_ValueChanged);
            // 
            // dtpto
            // 
            this.dtpto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpto.Checked = false;
            this.dtpto.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(643, 61);
            this.dtpto.Name = "dtpto";
            this.dtpto.ShowCheckBox = true;
            this.dtpto.Size = new System.Drawing.Size(209, 31);
            this.dtpto.TabIndex = 11;
            this.dtpto.ValueChanged += new System.EventHandler(this.dtpto_ValueChanged);
            // 
            // foxLabel1
            // 
            this.foxLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel1.ForeColor = System.Drawing.Color.White;
            this.foxLabel1.Location = new System.Drawing.Point(437, 32);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(62, 23);
            this.foxLabel1.TabIndex = 12;
            this.foxLabel1.Text = "From";
            // 
            // foxLabel2
            // 
            this.foxLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel2.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel2.ForeColor = System.Drawing.Color.White;
            this.foxLabel2.Location = new System.Drawing.Point(643, 32);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(62, 23);
            this.foxLabel2.TabIndex = 13;
            this.foxLabel2.Text = "To";
            // 
            // reportbtn
            // 
            this.reportbtn.BackColor = System.Drawing.Color.Transparent;
            this.reportbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.reportbtn.BorderColor = System.Drawing.Color.Transparent;
            this.reportbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.reportbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.reportbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.reportbtn.DownColor = System.Drawing.Color.Silver;
            this.reportbtn.EnabledCalc = true;
            this.reportbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.reportbtn.ForeColor = System.Drawing.Color.White;
            this.reportbtn.Location = new System.Drawing.Point(36, 52);
            this.reportbtn.Name = "reportbtn";
            this.reportbtn.OverColor = System.Drawing.Color.Black;
            this.reportbtn.Size = new System.Drawing.Size(185, 40);
            this.reportbtn.TabIndex = 14;
            this.reportbtn.Text = "Generate Report";
            this.reportbtn.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.reportbtn_Click);
            // 
            // FinishedJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(891, 470);
            this.Controls.Add(this.reportbtn);
            this.Controls.Add(this.foxLabel2);
            this.Controls.Add(this.foxLabel1);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.dtpfrom);
            this.Controls.Add(this.foxbutton);
            this.Controls.Add(this.MaterialCard);
            this.MinimumSize = new System.Drawing.Size(752, 393);
            this.Name = "FinishedJob";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FinishedJob_Load);
            this.MaterialCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.finishedjobgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard MaterialCard;
        private System.Windows.Forms.DataGridView finishedjobgrid;
        private ReaLTaiizor.Controls.FoxLabel foxbutton;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.DateTimePicker dtpto;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.FoxButton reportbtn;
    }
}