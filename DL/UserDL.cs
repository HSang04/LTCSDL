using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TO; 

namespace DL 
{
    public class UserDL : DataProvider
    {

        public User GetFirstUser()
        {
            string sql = "SELECT TOP 1 Username, Password FROM Users";  // Lấy 1 dòng đầu tiên

            SqlCommand cmd = new SqlCommand(sql, cn);  // Sử dụng cn (chữ thường) để kết nối

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);  // Đổ dữ liệu vào DataTable

            if (dt.Rows.Count > 0)
            {
                // Trả về thông tin người dùng đầu tiên
                User user = new User
                {
                    username = dt.Rows[0]["username"].ToString(),
                    password = dt.Rows[0]["password"].ToString()
                };
                return user;
            }
            else
            {
                return null;  // Nếu không có người dùng nào
            }


        }
         
        

        public bool CheckLogin(User user)
        {
           
            string sql = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@UserName", user.username);
            cmd.Parameters.AddWithValue("@Password", user.password);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            adapter.Fill(dt);
            if (dt.Tables[0].Rows.Count > 0) Console.WriteLine("QQ"); else Console.WriteLine("EE");
            return dt.Tables[0].Rows.Count > 0;
        }

    }
}
