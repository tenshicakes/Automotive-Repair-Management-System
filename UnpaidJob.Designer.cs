namespace Olvarra_Capstone
{
    partial class UnpaidJob
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
            this.materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            this.unpaidjobgrid = new System.Windows.Forms.DataGridView();
            this.foxbutton = new ReaLTaiizor.Controls.FoxLabel();
            this.updatebtn = new ReaLTaiizor.Controls.FoxButton();
            this.foxBigLabel6 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unpaidjobgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.unpaidjobgrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(23, 70);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(845, 291);
            this.materialCard1.TabIndex = 1;
            this.materialCard1.Paint += new System.Windows.Forms.PaintEventHandler(this.materialCard1_Paint);
            // 
            // unpaidjobgrid
            // 
            this.unpaidjobgrid.AllowUserToAddRows = false;
            this.unpaidjobgrid.AllowUserToDeleteRows = false;
            this.unpaidjobgrid.AllowUserToResizeColumns = false;
            this.unpaidjobgrid.AllowUserToResizeRows = false;
            this.unpaidjobgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.unpaidjobgrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.unpaidjobgrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unpaidjobgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.unpaidjobgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unpaidjobgrid.Location = new System.Drawing.Point(14, 14);
            this.unpaidjobgrid.MultiSelect = false;
            this.unpaidjobgrid.Name = "unpaidjobgrid";
            this.unpaidjobgrid.ReadOnly = true;
            this.unpaidjobgrid.RowHeadersVisible = false;
            this.unpaidjobgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.unpaidjobgrid.Size = new System.Drawing.Size(817, 263);
            this.unpaidjobgrid.TabIndex = 11;
            // 
            // foxbutton
            // 
            this.foxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxbutton.BackColor = System.Drawing.Color.Transparent;
            this.foxbutton.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxbutton.ForeColor = System.Drawing.Color.White;
            this.foxbutton.Location = new System.Drawing.Point(23, 12);
            this.foxbutton.Name = "foxbutton";
            this.foxbutton.Size = new System.Drawing.Size(514, 23);
            this.foxbutton.TabIndex = 8;
            this.foxbutton.Text = "Job Orders that are unpaid";
            // 
            // updatebtn
            // 
            this.updatebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updatebtn.BackColor = System.Drawing.Color.Transparent;
            this.updatebtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.updatebtn.BorderColor = System.Drawing.Color.Transparent;
            this.updatebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updatebtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.updatebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.updatebtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.updatebtn.DownColor = System.Drawing.Color.Silver;
            this.updatebtn.EnabledCalc = true;
            this.updatebtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(713, 368);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.OverColor = System.Drawing.Color.Black;
            this.updatebtn.Size = new System.Drawing.Size(155, 45);
            this.updatebtn.TabIndex = 18;
            this.updatebtn.Text = "Update ";
            this.updatebtn.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.addbtn_Click);
            // 
            // foxBigLabel6
            // 
            this.foxBigLabel6.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel6.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel6.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel6.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel6.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel6.Location = new System.Drawing.Point(23, 41);
            this.foxBigLabel6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 1);
            this.foxBigLabel6.Name = "foxBigLabel6";
            this.foxBigLabel6.Size = new System.Drawing.Size(488, 28);
            this.foxBigLabel6.TabIndex = 19;
            this.foxBigLabel6.Text = "Select a row and click the Update button to edit status and payment.";
            // 
            // UnpaidJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(891, 470);
            this.Controls.Add(this.foxBigLabel6);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.foxbutton);
            this.Controls.Add(this.materialCard1);
            this.MinimumSize = new System.Drawing.Size(907, 509);
            this.Name = "UnpaidJob";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnpaidJob";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UnpaidJob_Load);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unpaidjobgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DataGridView unpaidjobgrid;
        private ReaLTaiizor.Controls.FoxLabel foxbutton;
        private ReaLTaiizor.Controls.FoxButton updatebtn;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel6;
    }
}