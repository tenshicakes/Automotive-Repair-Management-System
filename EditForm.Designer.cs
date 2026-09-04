namespace Olvarra_Capstone
{
    partial class EditForm
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
            this.editinventorygrid = new System.Windows.Forms.DataGridView();
            this.foxBigLabel1 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.foxBigLabel2 = new ReaLTaiizor.Controls.FoxBigLabel();
            this.editinfobtn = new ReaLTaiizor.Controls.FoxButton();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editinventorygrid)).BeginInit();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.editinventorygrid);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(13, 97);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(513, 423);
            this.materialCard1.TabIndex = 2;
            // 
            // editinventorygrid
            // 
            this.editinventorygrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editinventorygrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.editinventorygrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editinventorygrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editinventorygrid.Location = new System.Drawing.Point(14, 14);
            this.editinventorygrid.Name = "editinventorygrid";
            this.editinventorygrid.RowHeadersVisible = false;
            this.editinventorygrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.editinventorygrid.Size = new System.Drawing.Size(485, 395);
            this.editinventorygrid.TabIndex = 0;
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
            this.foxBigLabel1.Size = new System.Drawing.Size(182, 41);
            this.foxBigLabel1.TabIndex = 3;
            this.foxBigLabel1.Text = "Edit Details";
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
            this.foxBigLabel2.TabIndex = 17;
            this.foxBigLabel2.Text = "Double each cell to edit information.";
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
            this.editinfobtn.Location = new System.Drawing.Point(12, 537);
            this.editinfobtn.Name = "editinfobtn";
            this.editinfobtn.OverColor = System.Drawing.Color.Black;
            this.editinfobtn.Size = new System.Drawing.Size(514, 70);
            this.editinfobtn.TabIndex = 18;
            this.editinfobtn.Text = "Save Changes";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(539, 625);
            this.Controls.Add(this.editinfobtn);
            this.Controls.Add(this.foxBigLabel2);
            this.Controls.Add(this.foxBigLabel1);
            this.Controls.Add(this.materialCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.materialCard1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editinventorygrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DataGridView editinventorygrid;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel1;
        private ReaLTaiizor.Controls.FoxBigLabel foxBigLabel2;
        private ReaLTaiizor.Controls.FoxButton editinfobtn;
    }
}