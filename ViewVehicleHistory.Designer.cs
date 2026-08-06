namespace Olvarra_Capstone
{
    partial class ViewVehicleHistory
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
            this.vehiclehistorygrid = new System.Windows.Forms.DataGridView();
            this.vehiclenamelbl = new ReaLTaiizor.Controls.FoxBigLabel();
            this.vehicleplatelbl = new ReaLTaiizor.Controls.FoxBigLabel();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclehistorygrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.vehiclehistorygrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(23, 121);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(824, 306);
            this.materialCard1.TabIndex = 4;
            // 
            // vehiclehistorygrid
            // 
            this.vehiclehistorygrid.AllowUserToAddRows = false;
            this.vehiclehistorygrid.AllowUserToDeleteRows = false;
            this.vehiclehistorygrid.AllowUserToResizeColumns = false;
            this.vehiclehistorygrid.AllowUserToResizeRows = false;
            this.vehiclehistorygrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vehiclehistorygrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.vehiclehistorygrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vehiclehistorygrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vehiclehistorygrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vehiclehistorygrid.Location = new System.Drawing.Point(14, 14);
            this.vehiclehistorygrid.MultiSelect = false;
            this.vehiclehistorygrid.Name = "vehiclehistorygrid";
            this.vehiclehistorygrid.ReadOnly = true;
            this.vehiclehistorygrid.RowHeadersVisible = false;
            this.vehiclehistorygrid.RowHeadersWidth = 51;
            this.vehiclehistorygrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.vehiclehistorygrid.Size = new System.Drawing.Size(796, 278);
            this.vehiclehistorygrid.TabIndex = 9;
            // 
            // vehiclenamelbl
            // 
            this.vehiclenamelbl.BackColor = System.Drawing.Color.Transparent;
            this.vehiclenamelbl.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehiclenamelbl.ForeColor = System.Drawing.Color.White;
            this.vehiclenamelbl.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.vehiclenamelbl.LineColor = System.Drawing.Color.Transparent;
            this.vehiclenamelbl.Location = new System.Drawing.Point(23, 23);
            this.vehiclenamelbl.Name = "vehiclenamelbl";
            this.vehiclenamelbl.Size = new System.Drawing.Size(271, 31);
            this.vehiclenamelbl.TabIndex = 5;
            this.vehiclenamelbl.Text = "Dashboard Overview";
            // 
            // vehicleplatelbl
            // 
            this.vehicleplatelbl.BackColor = System.Drawing.Color.Transparent;
            this.vehicleplatelbl.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleplatelbl.ForeColor = System.Drawing.Color.White;
            this.vehicleplatelbl.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.vehicleplatelbl.LineColor = System.Drawing.Color.Transparent;
            this.vehicleplatelbl.Location = new System.Drawing.Point(23, 73);
            this.vehicleplatelbl.Name = "vehicleplatelbl";
            this.vehicleplatelbl.Size = new System.Drawing.Size(271, 31);
            this.vehicleplatelbl.TabIndex = 6;
            this.vehicleplatelbl.Text = "Dashboard Overview";
            // 
            // ViewVehicleHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.vehicleplatelbl);
            this.Controls.Add(this.vehiclenamelbl);
            this.Controls.Add(this.materialCard1);
            this.MinimumSize = new System.Drawing.Size(886, 489);
            this.Name = "ViewVehicleHistory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ViewVehicleHistory_Load);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vehiclehistorygrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DataGridView vehiclehistorygrid;
        private ReaLTaiizor.Controls.FoxBigLabel vehiclenamelbl;
        private ReaLTaiizor.Controls.FoxBigLabel vehicleplatelbl;
    }
}