namespace Olvarra_Capstone
{
    partial class AddParts
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
            this.availpartsgrid = new System.Windows.Forms.DataGridView();
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.addbtn = new ReaLTaiizor.Controls.FoxButton();
            this.cancelbtn = new ReaLTaiizor.Controls.FoxButton();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availpartsgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.availpartsgrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(31, 101);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(19, 17, 19, 17);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(19, 17, 19, 17);
            this.materialCard1.Size = new System.Drawing.Size(576, 347);
            this.materialCard1.TabIndex = 0;
            // 
            // availpartsgrid
            // 
            this.availpartsgrid.AllowUserToAddRows = false;
            this.availpartsgrid.AllowUserToDeleteRows = false;
            this.availpartsgrid.AllowUserToResizeColumns = false;
            this.availpartsgrid.AllowUserToResizeRows = false;
            this.availpartsgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.availpartsgrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.availpartsgrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.availpartsgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availpartsgrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.availpartsgrid.Location = new System.Drawing.Point(19, 17);
            this.availpartsgrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.availpartsgrid.Name = "availpartsgrid";
            this.availpartsgrid.ReadOnly = true;
            this.availpartsgrid.RowHeadersVisible = false;
            this.availpartsgrid.RowHeadersWidth = 51;
            this.availpartsgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availpartsgrid.Size = new System.Drawing.Size(538, 313);
            this.availpartsgrid.TabIndex = 11;
            // 
            // foxLabel2
            // 
            this.foxLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel2.Font = new System.Drawing.Font("Candara", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel2.ForeColor = System.Drawing.Color.Black;
            this.foxLabel2.Location = new System.Drawing.Point(185, 42);
            this.foxLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(247, 38);
            this.foxLabel2.TabIndex = 6;
            this.foxLabel2.Text = "Available Parts";
            // 
            // addbtn
            // 
            this.addbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addbtn.BackColor = System.Drawing.Color.Transparent;
            this.addbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.addbtn.BorderColor = System.Drawing.Color.Transparent;
            this.addbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.addbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.addbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.addbtn.DownColor = System.Drawing.Color.Silver;
            this.addbtn.EnabledCalc = true;
            this.addbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(400, 469);
            this.addbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addbtn.Name = "addbtn";
            this.addbtn.OverColor = System.Drawing.Color.Black;
            this.addbtn.Size = new System.Drawing.Size(207, 55);
            this.addbtn.TabIndex = 17;
            this.addbtn.Text = "Add";
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelbtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.cancelbtn.BorderColor = System.Drawing.Color.Transparent;
            this.cancelbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cancelbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.cancelbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.cancelbtn.DownColor = System.Drawing.Color.Silver;
            this.cancelbtn.EnabledCalc = true;
            this.cancelbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.cancelbtn.ForeColor = System.Drawing.Color.White;
            this.cancelbtn.Location = new System.Drawing.Point(185, 469);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.OverColor = System.Drawing.Color.Black;
            this.cancelbtn.Size = new System.Drawing.Size(207, 55);
            this.cancelbtn.TabIndex = 18;
            this.cancelbtn.Text = "Cancel";
            // 
            // AddParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 544);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.foxLabel2);
            this.Controls.Add(this.materialCard1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 591);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 591);
            this.Name = "AddParts";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.AddParts_Load);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.availpartsgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private System.Windows.Forms.DataGridView availpartsgrid;
        private ReaLTaiizor.Controls.FoxButton addbtn;
        private ReaLTaiizor.Controls.FoxButton cancelbtn;
    }
}