using BL;
using GK_Test2.SupHT;
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

namespace GK_Test2
{
    public partial class FrmSup : Form
    {
        private SupBL supBL;
        public FrmSup()
        {
            InitializeComponent();
            supBL = new SupBL();
        }

        private void Sup_Load(object sender, EventArgs e)
        {
            dgvSup.DataSource = supBL.GetSuppliers();

            if (dgvSup.Columns.Contains("Edit") || dgvSup.Columns.Contains("Delete"))
            {
                dgvSup.Columns.Remove("Edit");
                dgvSup.Columns.Remove("Delete");
            }


            DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
            editColumn.Name = "Edit";
            editColumn.HeaderText = "Sửa";
            editColumn.Image = Image.FromFile("edit.jpg");
            editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvSup.Columns.Add(editColumn);


            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.Name = "Delete";
            deleteColumn.HeaderText = "Xóa";
            deleteColumn.Image = Image.FromFile("delete.jpg");
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvSup.Columns.Add(deleteColumn);

            dgvSup.CellClick += dgvSup_CellClick;
        }

        private void dgvSup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvSup.Rows[e.RowIndex].Cells["id"].Value.ToString();

                // Click cột Sửa
                if (dgvSup.Columns[e.ColumnIndex].Name == "Edit")
                {
                    MessageBox.Show($"Bạn muốn sửa dòng có ID = {id}");

                }


                if (dgvSup.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (supBL.DeleteSupplier(id))
                        {
                            MessageBox.Show("Xóa thành công!");
                            Sup_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại!");
                        }
                    }
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            AddSupp formAdd = new AddSupp();
            formAdd.parentForm = this;
            
            DialogResult result = formAdd.ShowDialog();
            if(result == DialogResult.Yes)
            {
                dgvSup.DataSource = supBL.GetSuppliers();
            }


        }
    }
}