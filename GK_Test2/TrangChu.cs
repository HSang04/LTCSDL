using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Test2
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            this.Show();
            Enabled = false;
            Login dn = new Login();
            DialogResult result = dn.ShowDialog();
            if (result == DialogResult.OK)
            {
                Enabled = true;
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
