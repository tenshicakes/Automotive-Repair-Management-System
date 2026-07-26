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
    public partial class UpdatePending : Form
    {
        public UpdatePending()
        {
            InitializeComponent();
        }

        private void addpartsbtn_Click(object sender, EventArgs e)
        {
            AddParts addparts = new AddParts();
            addparts.ShowDialog();
        }
    }
}
