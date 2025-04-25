using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO;

namespace GK_Test2.SupHT
{
    public partial class AddSupp : Form
    {
        public FrmSup parentForm;
        private SupBL supBL = new SupBL();
        public AddSupp()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Sup s = new Sup
            {
                Id = tbID.Text.Trim(),
                Name = tbName.Text.Trim(),
                Address = tbAddress.Text.Trim()
            };

            if (supBL.AddSupplier(s))
            {
                MessageBox.Show("Thêm thành công!"); 
                this.DialogResult = DialogResult.Yes;    
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }
    }
}
