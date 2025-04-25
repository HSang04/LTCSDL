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

            //dgvSup.CellClick += dgvSup_CellClick;
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

        private void dgvSup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvSup.Columns["Edit"].Index)
                {
                    string supplierId = dgvSup.Rows[e.RowIndex].Cells["Id"].Value?.ToString();

                    if (!string.IsNullOrEmpty(supplierId))
                    {
                        EditSup formEdit = new EditSup(supplierId);
                        DialogResult result = formEdit.ShowDialog();
                        if (result == DialogResult.Yes)
                        {
                            dgvSup.DataSource = supBL.GetSuppliers();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ID của nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

              
                else if (e.ColumnIndex == dgvSup.Columns["Delete"].Index)
                {
                 
                    string supplierId = dgvSup.Rows[e.RowIndex].Cells["Id"].Value?.ToString();

                    if (!string.IsNullOrEmpty(supplierId))
                    {
                        DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmResult == DialogResult.Yes)
                        {
                            bool isDeleted = supBL.DeleteSupplier(supplierId);
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvSup.DataSource = supBL.GetSuppliers(); 
                            }
                            else
                            {
                                MessageBox.Show("Xóa nhà cung cấp thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ID của nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}