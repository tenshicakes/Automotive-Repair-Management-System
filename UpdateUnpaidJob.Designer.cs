namespace Olvarra_Capstone
{
    partial class UpdateUnpaidJob
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
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.amountpaid_txtbox = new ReaLTaiizor.Controls.DungeonTextBox();
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.updatestatus = new ReaLTaiizor.Controls.DungeonComboBox();
            this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
            this.processby_txtbox = new ReaLTaiizor.Controls.DungeonTextBox();
            this.updatebtn = new ReaLTaiizor.Controls.FoxButton();
            this.SuspendLayout();
            // 
            // foxLabel2
            // 
            this.foxLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel2.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel2.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel2.ForeColor = System.Drawing.Color.Black;
            this.foxLabel2.Location = new System.Drawing.Point(12, 12);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(191, 23);
            this.foxLabel2.TabIndex = 6;
            this.foxLabel2.Text = "Total Amount Paid";
            // 
            // amountpaid_txtbox
            // 
            this.amountpaid_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amountpaid_txtbox.BackColor = System.Drawing.Color.Transparent;
            this.amountpaid_txtbox.BorderColor = System.Drawing.Color.Transparent;
            this.amountpaid_txtbox.EdgeColor = System.Drawing.Color.White;
            this.amountpaid_txtbox.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.amountpaid_txtbox.ForeColor = System.Drawing.Color.Black;
            this.amountpaid_txtbox.Location = new System.Drawing.Point(12, 41);
            this.amountpaid_txtbox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.amountpaid_txtbox.MaximumSize = new System.Drawing.Size(273, 36);
            this.amountpaid_txtbox.MaxLength = 32767;
            this.amountpaid_txtbox.MinimumSize = new System.Drawing.Size(273, 36);
            this.amountpaid_txtbox.Multiline = false;
            this.amountpaid_txtbox.Name = "amountpaid_txtbox";
            this.amountpaid_txtbox.ReadOnly = false;
            this.amountpaid_txtbox.Size = new System.Drawing.Size(273, 36);
            this.amountpaid_txtbox.TabIndex = 10;
            this.amountpaid_txtbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.amountpaid_txtbox.UseSystemPasswordChar = false;
            // 
            // foxLabel1
            // 
            this.foxLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel1.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel1.ForeColor = System.Drawing.Color.Black;
            this.foxLabel1.Location = new System.Drawing.Point(12, 198);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(157, 23);
            this.foxLabel1.TabIndex = 11;
            this.foxLabel1.Text = "Update Status";
            // 
            // updatestatus
            // 
            this.updatestatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updatestatus.BackColor = System.Drawing.Color.White;
            this.updatestatus.ColorA = System.Drawing.Color.Black;
            this.updatestatus.ColorB = System.Drawing.Color.Black;
            this.updatestatus.ColorC = System.Drawing.Color.White;
            this.updatestatus.ColorD = System.Drawing.Color.White;
            this.updatestatus.ColorE = System.Drawing.Color.White;
            this.updatestatus.ColorF = System.Drawing.Color.Black;
            this.updatestatus.ColorG = System.Drawing.Color.Black;
            this.updatestatus.ColorH = System.Drawing.Color.White;
            this.updatestatus.ColorI = System.Drawing.Color.Black;
            this.updatestatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updatestatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.updatestatus.DropDownHeight = 500;
            this.updatestatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.updatestatus.DropDownWidth = 243;
            this.updatestatus.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatestatus.ForeColor = System.Drawing.Color.Black;
            this.updatestatus.FormattingEnabled = true;
            this.updatestatus.HoverSelectionColor = System.Drawing.Color.Black;
            this.updatestatus.IntegralHeight = false;
            this.updatestatus.ItemHeight = 40;
            this.updatestatus.Items.AddRange(new object[] {
            "Finished",
            "Pending"});
            this.updatestatus.Location = new System.Drawing.Point(12, 227);
            this.updatestatus.MaxDropDownItems = 4;
            this.updatestatus.Name = "updatestatus";
            this.updatestatus.Size = new System.Drawing.Size(273, 46);
            this.updatestatus.StartIndex = 0;
            this.updatestatus.TabIndex = 15;
            // 
            // foxLabel3
            // 
            this.foxLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxLabel3.BackColor = System.Drawing.Color.Transparent;
            this.foxLabel3.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxLabel3.ForeColor = System.Drawing.Color.Black;
            this.foxLabel3.Location = new System.Drawing.Point(12, 105);
            this.foxLabel3.Name = "foxLabel3";
            this.foxLabel3.Size = new System.Drawing.Size(123, 23);
            this.foxLabel3.TabIndex = 16;
            this.foxLabel3.Text = "Processed By:";
            // 
            // processby_txtbox
            // 
            this.processby_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processby_txtbox.BackColor = System.Drawing.Color.Transparent;
            this.processby_txtbox.BorderColor = System.Drawing.Color.Transparent;
            this.processby_txtbox.EdgeColor = System.Drawing.Color.White;
            this.processby_txtbox.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold);
            this.processby_txtbox.ForeColor = System.Drawing.Color.Black;
            this.processby_txtbox.Location = new System.Drawing.Point(12, 134);
            this.processby_txtbox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 25);
            this.processby_txtbox.MaximumSize = new System.Drawing.Size(273, 36);
            this.processby_txtbox.MaxLength = 32767;
            this.processby_txtbox.MinimumSize = new System.Drawing.Size(273, 36);
            this.processby_txtbox.Multiline = false;
            this.processby_txtbox.Name = "processby_txtbox";
            this.processby_txtbox.ReadOnly = false;
            this.processby_txtbox.Size = new System.Drawing.Size(273, 36);
            this.processby_txtbox.TabIndex = 17;
            this.processby_txtbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.processby_txtbox.UseSystemPasswordChar = false;
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
            this.updatebtn.Location = new System.Drawing.Point(12, 291);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.OverColor = System.Drawing.Color.Black;
            this.updatebtn.Size = new System.Drawing.Size(273, 56);
            this.updatebtn.TabIndex = 19;
            this.updatebtn.Text = "Update ";
            // 
            // UpdateUnpaidJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 383);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.processby_txtbox);
            this.Controls.Add(this.foxLabel3);
            this.Controls.Add(this.updatestatus);
            this.Controls.Add(this.foxLabel1);
            this.Controls.Add(this.amountpaid_txtbox);
            this.Controls.Add(this.foxLabel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(323, 422);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(323, 422);
            this.Name = "UpdateUnpaidJob";
            this.ShowIcon = false;
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.DungeonTextBox amountpaid_txtbox;
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.DungeonComboBox updatestatus;
        private ReaLTaiizor.Controls.FoxLabel foxLabel3;
        private ReaLTaiizor.Controls.DungeonTextBox processby_txtbox;
        private ReaLTaiizor.Controls.FoxButton updatebtn;
    }
}