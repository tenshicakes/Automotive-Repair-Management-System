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
            this.finishedjobgrid = new ReaLTaiizor.Controls.MaterialCard();
            this.unpaidjobgrid = new System.Windows.Forms.DataGridView();
            this.foxbutton = new ReaLTaiizor.Controls.FoxLabel();
            this.finishedjobgrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unpaidjobgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // finishedjobgrid
            // 
            this.finishedjobgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.finishedjobgrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.finishedjobgrid.Controls.Add(this.unpaidjobgrid);
            this.finishedjobgrid.Depth = 0;
            this.finishedjobgrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.finishedjobgrid.Location = new System.Drawing.Point(36, 69);
            this.finishedjobgrid.Margin = new System.Windows.Forms.Padding(14);
            this.finishedjobgrid.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.finishedjobgrid.Name = "finishedjobgrid";
            this.finishedjobgrid.Padding = new System.Windows.Forms.Padding(14);
            this.finishedjobgrid.Size = new System.Drawing.Size(661, 249);
            this.finishedjobgrid.TabIndex = 2;
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
            this.unpaidjobgrid.Size = new System.Drawing.Size(633, 221);
            this.unpaidjobgrid.TabIndex = 11;
            // 
            // foxbutton
            // 
            this.foxbutton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foxbutton.BackColor = System.Drawing.Color.Transparent;
            this.foxbutton.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foxbutton.ForeColor = System.Drawing.Color.White;
            this.foxbutton.Location = new System.Drawing.Point(36, 29);
            this.foxbutton.Name = "foxbutton";
            this.foxbutton.Size = new System.Drawing.Size(267, 23);
            this.foxbutton.TabIndex = 9;
            this.foxbutton.Text = "Job Orders that are finished ";
            this.foxbutton.Click += new System.EventHandler(this.foxbutton_Click);
            // 
            // FinishedJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(736, 354);
            this.Controls.Add(this.foxbutton);
            this.Controls.Add(this.finishedjobgrid);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(752, 393);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(752, 393);
            this.Name = "FinishedJob";
            this.ShowIcon = false;
            this.finishedjobgrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.unpaidjobgrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard finishedjobgrid;
        private System.Windows.Forms.DataGridView unpaidjobgrid;
        private ReaLTaiizor.Controls.FoxLabel foxbutton;
    }
}