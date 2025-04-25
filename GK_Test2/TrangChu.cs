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
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
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

        private void AddForm(Form form)
        {
            form.TopLevel = false;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(form);

            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }
        private void btCongTy_Click(object sender, EventArgs e)
        {
           FrmSup sup = new FrmSup();
           AddForm(sup);
        }

      
    }
}
