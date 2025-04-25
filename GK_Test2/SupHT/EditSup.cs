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
    public partial class EditSup : Form
    {
        public FrmSup parentForm;
        private SupBL supBL = new SupBL();
        private string idTMP;

        private string supplierId;
        public EditSup(string supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
            Console.WriteLine("Sang + " + supplierId);
            
           
        }


        private void EditSup_Load(object sender, EventArgs e)
        {
            Sup supplier = supBL.GetSupplierById(supplierId);
            if (supplier != null)
            {
                tbID.Text = supplier.Id;
                tbTen.Text = supplier.Name;
                tbDiaChi.Text = supplier.Address;
                idTMP = supplier.Id;
                tbID.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Sup updatedSupplier = new Sup
            {
                Id = idTMP,
                Name = tbTen.Text,
                Address = tbDiaChi.Text
                
            };
            Console.WriteLine("Khuya " + idTMP);
            bool isUpdated = supBL.EditSupplier(updatedSupplier);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật thành công.");
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

            this.Close();
        }

      
    }
}
