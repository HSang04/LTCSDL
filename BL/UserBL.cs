using DL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
    public class UserBL
    {
        private UserDL userDL = new UserDL();

        public bool Login(User user)
        {
            try
            {
                return userDL.CheckLogin(user);
            }
            catch (SqlException ex) { throw ex; }
        }

        public User GetFirstUser()
        {
            return userDL.GetFirstUser();  // Gọi phương thức GetFirstUser của UserDL
        }
    }
}
