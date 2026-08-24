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
            this.MaterialCard.Location = new System.Drawing.Point(36, 69);
            this.MaterialCard.Margin = new System.Windows.Forms.Padding(14);
            this.MaterialCard.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.MaterialCard.Name = "MaterialCard";
            this.MaterialCard.Padding = new System.Windows.Forms.Padding(14);
            this.MaterialCard.Size = new System.Drawing.Size(816, 365);
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
            this.finishedjobgrid.Size = new System.Drawing.Size(788, 337);
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
            this.foxbutton.Location = new System.Drawing.Point(36, 29);
            this.foxbutton.Name = "foxbutton";
            this.foxbutton.Size = new System.Drawing.Size(422, 23);
            this.foxbutton.TabIndex = 9;
            this.foxbutton.Text = "Job Orders that are finished ";
            this.foxbutton.Click += new System.EventHandler(this.foxbutton_Click);
            // 
            // FinishedJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(107)))), ((int)(((byte)(109)))));
            this.ClientSize = new System.Drawing.Size(891, 470);
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
    }
}