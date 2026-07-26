using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class UnpaidJob : Form
    {
        public UnpaidJob()
        {
            InitializeComponent();
        }

        private void UnpaidJob_Load(object sender, EventArgs e)
        {

        }


        //==========================
        // UPDATE BUTTON
        //==========================
        private void addbtn_Click(object sender, EventArgs e)
        {
            UpdateUnpaidJob update = new UpdateUnpaidJob();
            update.ShowDialog();
        }
    }
}
