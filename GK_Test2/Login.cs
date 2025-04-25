using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO;

namespace GK_Test2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text.ToString();
            string password = tbMatKhau.Text.ToString();

            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng user
            User user = new User(username, password);
            UserBL bl = new UserBL();
            try
            {
                if (bl.Login(user))
                {
                    MessageBox.Show("✅ Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    // TODO: Chuyển sang form chính hoặc lưu thông tin user lại
                    // this.Hide(); new MainForm().Show(); hoặc lưu user vào biến toàn cục
                }
                else
                {
                    MessageBox.Show("❌ Sai tài khoản hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbMatKhau.Clear();
                    tbMatKhau.Focus();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UserBL bl = new UserBL();
            User user = bl.GetFirstUser();  // Lấy thông tin người dùng đầu tiên

            if (user != null)
            {
                tbUsername.Text = user.username;  // Điền vào TextBox Username
                tbMatKhau.Text = user.password;   // Điền vào TextBox Password
            }
            else
            {
                MessageBox.Show("Không có người dùng trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
