namespace Olvarra_Capstone
{
    partial class EditInventory
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
            this.inventorygrid = new System.Windows.Forms.DataGridView();
            this.materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            this.foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.addstockbtn = new ReaLTaiizor.Controls.FoxButton();
            this.reducestockbtn = new ReaLTaiizor.Controls.FoxButton();
            this.foxBigLabel2 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.editinfobtn = new ReaLTaiizor.Controls.FoxButton();
            this.addnewbtn = new ReaLTaiizor.Controls.FoxButton();
            this.foxBigLabel3 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.foxBigLabel4 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.foxBigLabel5 = new ReaLTaiizor.Controls.FoxBigLabel();
            ((System.ComponentModel.ISupportInitialize)(this.inventorygrid)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inventorygrid
            // 
            this.inventorygrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventorygrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.inventorygrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventorygrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventorygrid.Location = new System.Drawing.Point(14, 14);
            this.inventorygrid.Name = "inventorygrid";
            this.inventorygrid.ReadOnly = true;
            this.inventorygrid.RowHeadersVisible = false;
            this.inventorygrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventorygrid.Size = new System.Drawing.Size(500, 395);
            this.inventorygrid.TabIndex = 0;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.inventorygrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(13, 91);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(528, 423);
            this.materialCard1.TabIndex = 1;
            // 
            // foxBigLabel1
            // 
            this.foxBigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel1.Font = new System.Drawing.Font("Candara", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel1.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel1.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel1.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel1.Location = new System.Drawing.Point(13, 12);
            this.foxBigLabel1.Name = "foxBigLabel1";
            this.foxBigLabel1.Size = new System.Drawing.Size(165, 41);
            this.foxBigLabel1.TabIndex = 2;
            this.foxBigLabel1.Text = "Inventory";
            // 
            // addstockbtn
            // 
            this.addstockbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addstockbtn.BackColor = System.Drawing.Color.Transparent;
            this.addstockbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.addstockbtn.BorderColor = System.Drawing.Color.Transparent;
            this.addstockbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addstockbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.addstockbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.addstockbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.addstockbtn.DownColor = System.Drawing.Color.Silver;
            this.addstockbtn.EnabledCalc = true;
            this.addstockbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.addstockbtn.ForeColor = System.Drawing.Color.White;
            this.addstockbtn.Location = new System.Drawing.Point(551, 125);
            this.addstockbtn.Name = "addstockbtn";
            this.addstockbtn.OverColor = System.Drawing.Color.Black;
            this.addstockbtn.Size = new System.Drawing.Size(385, 56);
            this.addstockbtn.TabIndex = 14;
            this.addstockbtn.Text = "Add Stock +";
            this.addstockbtn.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.addstockbtn_Click);
            // 
            // reducestockbtn
            // 
            this.reducestockbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reducestockbtn.BackColor = System.Drawing.Color.Transparent;
            this.reducestockbtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.reducestockbtn.BorderColor = System.Drawing.Color.Transparent;
            this.reducestockbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reducestockbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.reducestockbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.reducestockbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.reducestockbtn.DownColor = System.Drawing.Color.Silver;
            this.reducestockbtn.EnabledCalc = true;
            this.reducestockbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.reducestockbtn.ForeColor = System.Drawing.Color.White;
            this.reducestockbtn.Location = new System.Drawing.Point(551, 187);
            this.reducestockbtn.Name = "reducestockbtn";
            this.reducestockbtn.OverColor = System.Drawing.Color.Black;
            this.reducestockbtn.Size = new System.Drawing.Size(385, 56);
            this.reducestockbtn.TabIndex = 15;
            this.reducestockbtn.Text = "Reduce Stock -";
            this.reducestockbtn.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.reducestockbtn_Click);
            // 
            // foxBigLabel2
            // 
            this.foxBigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel2.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel2.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel2.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel2.Location = new System.Drawing.Point(13, 59);
            this.foxBigLabel2.Name = "foxBigLabel2";
            this.foxBigLabel2.Size = new System.Drawing.Size(338, 28);
            this.foxBigLabel2.TabIndex = 16;
            this.foxBigLabel2.Text = "Select rows and click the desired action.";
            // 
            // editinfobtn
            // 
            this.editinfobtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editinfobtn.BackColor = System.Drawing.Color.Transparent;
            this.editinfobtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.editinfobtn.BorderColor = System.Drawing.Color.Transparent;
            this.editinfobtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editinfobtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.editinfobtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.editinfobtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.editinfobtn.DownColor = System.Drawing.Color.Silver;
            this.editinfobtn.EnabledCalc = true;
            this.editinfobtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.editinfobtn.ForeColor = System.Drawing.Color.White;
            this.editinfobtn.Location = new System.Drawing.Point(551, 322);
            this.editinfobtn.Name = "editinfobtn";
            this.editinfobtn.OverColor = System.Drawing.Color.Black;
            this.editinfobtn.Size = new System.Drawing.Size(385, 56);
            this.editinfobtn.TabIndex = 17;
            this.editinfobtn.Text = "Edit Information";
            this.editinfobtn.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.editinfobtn_Click);
            // 
            // addnewbtn
            // 
            this.addnewbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addnewbtn.BackColor = System.Drawing.Color.Transparent;
            this.addnewbtn.BaseColor = System.Drawing.Color.White;
            this.addnewbtn.BorderColor = System.Drawing.Color.Transparent;
            this.addnewbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addnewbtn.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.addnewbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.addnewbtn.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.addnewbtn.DownColor = System.Drawing.Color.Silver;
            this.addnewbtn.EnabledCalc = true;
            this.addnewbtn.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.addnewbtn.ForeColor = System.Drawing.Color.Black;
            this.addnewbtn.Location = new System.Drawing.Point(551, 457);
            this.addnewbtn.Name = "addnewbtn";
            this.addnewbtn.OverColor = System.Drawing.Color.Black;
            this.addnewbtn.Size = new System.Drawing.Size(385, 56);
            this.addnewbtn.TabIndex = 21;
            this.addnewbtn.Text = "Add New +";
            // 
            // foxBigLabel3
            // 
            this.foxBigLabel3.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel3.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel3.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel3.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel3.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel3.Location = new System.Drawing.Point(551, 91);
            this.foxBigLabel3.Name = "foxBigLabel3";
            this.foxBigLabel3.Size = new System.Drawing.Size(158, 28);
            this.foxBigLabel3.TabIndex = 22;
            this.foxBigLabel3.Text = "Stock Adjustment";
            // 
            // foxBigLabel4
            // 
            this.foxBigLabel4.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel4.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel4.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel4.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel4.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel4.Location = new System.Drawing.Point(551, 288);
            this.foxBigLabel4.Name = "foxBigLabel4";
            this.foxBigLabel4.Size = new System.Drawing.Size(171, 28);
            this.foxBigLabel4.TabIndex = 23;
            this.foxBigLabel4.Text = "Edit Product Details";
            // 
            // foxBigLabel5
            // 
            this.foxBigLabel5.BackColor = System.Drawing.Color.Transparent;
            this.foxBigLabel5.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxBigLabel5.ForeColor = System.Drawing.Color.White;
            this.foxBigLabel5.Line = ReaLTaiizor.Controls.FoxBigLabel.Direction.Bottom;
            this.foxBigLabel5.LineColor = System.Drawing.Color.Transparent;
            this.foxBigLabel5.Location = new System.Drawing.Point(551, 423);
            this.foxBigLabel5.Name = "foxBigLabel5";
            this.foxBigLabel5.Size = new System.Drawing.Size(171, 28);
            this.foxBigLabel5.TabIndex = 24;
            this.foxBigLabel5.Text = "Add More Products";
            // 
            // EditInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(945, 525);
            this.Controls.Add(this.foxBigLabel5);
            this.Controls.Add(this.foxBigLabel4);
            this.Controls.Add(this.foxBigLabel3);
            this.Controls.Add(this.addnewbtn);
            this.Controls.Add(this.editinfobtn);
            this.Controls.Add(this.foxBigLabel2);
            this.Controls.Add(this.reducestockbtn);
            this.Controls.Add(this.addstockbtn);
            this.Controls.Add(this.foxBigLabel1);
            this.Controls.Add(this.materialCard1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(961, 564);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(961, 564);
            this.Name = "EditInventory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventorygrid)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView inventorygrid;
        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
        private ReaLTaiizor.Controls.FoxButton addstockbtn;
        private ReaLTaiizor.Controls.FoxButton reducestockbtn;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel2;
        private ReaLTaiizor.Controls.FoxButton editinfobtn;
        private ReaLTaiizor.Controls.FoxButton addnewbtn;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel3;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel4;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel5;
    }
}