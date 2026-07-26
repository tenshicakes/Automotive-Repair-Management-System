namespace Olvarra_Capstone
{
    partial class Fulldetails
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
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
            this.serviceloggrid = new System.Windows.Forms.DataGridView();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serviceloggrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.serviceloggrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(23, 85);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(795, 294);
            this.materialCard1.TabIndex = 0;
            // 
            // foxLabel2
            // 
            this.foxLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel2.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel2.ForeColor = System.Drawing.Color.White;
            this.foxLabel2.Location = new System.Drawing.Point(633, 24);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(185, 31);
            this.foxLabel2.TabIndex = 6;
            this.foxLabel2.Text = "Service History";
            // 
            // foxLabel1
            // 
            this.foxLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel1.ForeColor = System.Drawing.Color.White;
            this.foxLabel1.Location = new System.Drawing.Point(23, 12);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(205, 31);
            this.foxLabel1.TabIndex = 7;
            this.foxLabel1.Text = "Toyota Wigo";
            // 
            // foxLabel3
            // 
            this.foxLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel3.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel3.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel3.ForeColor = System.Drawing.Color.White;
            this.foxLabel3.Location = new System.Drawing.Point(23, 49);
            this.foxLabel3.Name = "foxLabel3";
            this.foxLabel3.Size = new System.Drawing.Size(205, 29);
            this.foxLabel3.TabIndex = 8;
            this.foxLabel3.Text = "NEO 2125";
            // 
            // serviceloggrid
            // 
            this.serviceloggrid.AllowUserToAddRows = false;
            this.serviceloggrid.AllowUserToDeleteRows = false;
            this.serviceloggrid.AllowUserToResizeColumns = false;
            this.serviceloggrid.AllowUserToResizeRows = false;
            this.serviceloggrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.serviceloggrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.serviceloggrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serviceloggrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.serviceloggrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceloggrid.Location = new System.Drawing.Point(14, 14);
            this.serviceloggrid.Name = "serviceloggrid";
            this.serviceloggrid.ReadOnly = true;
            this.serviceloggrid.RowHeadersVisible = false;
            this.serviceloggrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.serviceloggrid.Size = new System.Drawing.Size(767, 266);
            this.serviceloggrid.TabIndex = 11;
            // 
            // Fulldetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(841, 450);
            this.Controls.Add(this.foxLabel3);
            this.Controls.Add(this.foxLabel1);
            this.Controls.Add(this.foxLabel2);
            this.Controls.Add(this.materialCard1);
            this.Name = "Fulldetails";
            this.Text = " ";
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serviceloggrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel3;
        private System.Windows.Forms.DataGridView serviceloggrid;
    }
}