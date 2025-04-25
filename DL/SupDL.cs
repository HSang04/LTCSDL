using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TO;

namespace DL
{
    public class SupDL : DataProvider
    {
        public DataSet GetSuppliers()
        {
            DataSet ds = new DataSet();
            string sql = "SELECT * FROM Supplier";
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                adapter.Fill(ds, "Supplier");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            return ds;
        }

        public bool AddSupplier(Sup s)
        {
            string sql = "INSERT INTO Supplier (Id, Name, Address) VALUES (@id, @name, @address)";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", s.Id);
                cmd.Parameters.AddWithValue("@name", s.Name);
                cmd.Parameters.AddWithValue("@address", s.Address);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool UpdateSupplier(Sup s)
        {
            string sql = "UPDATE Supplier SET Name = @name, Address = @address WHERE Id = @id";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", s.Id);
                cmd.Parameters.AddWithValue("@name", s.Name);
                cmd.Parameters.AddWithValue("@address", s.Address);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool DeleteSupplier(string id)
        {
            string sql = "DELETE FROM Supplier WHERE Id = @id";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", id);
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public Sup GetSupplierById(string supplierId)
        {
            Console.WriteLine("Chieu " + supplierId);
            Sup supplier = null;
            string sql = "SELECT * FROM Supplier WHERE Id = @id";

            try
            {
               
                if (!string.IsNullOrEmpty(supplierId))
                {
                    Connect();  
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                    adapter.SelectCommand.Parameters.AddWithValue("@id", supplierId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        supplier = new Sup
                        {
                            // Lấy Id dưới dạng string
                            Id = row["Id"].ToString(),
                            Name = row["Name"].ToString(),
                            Address = row["Address"].ToString()
                        };
                    }
                }
                else
                {
                    MessageBox.Show("ID không hợp lệ. Vui lòng nhập ID hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();  
            }

            return supplier;
        }

        public bool EditSupplier(Sup s)
        {
            string sql = "SELECT * FROM Supplier WHERE Id = @id";
            Console.WriteLine("Toi " + s.Id);
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", s.Id);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                DataTable dt = new DataTable();
                adapter.Fill(dt); 

                if (dt.Rows.Count > 0)
                {
                   
                    DataRow row = dt.Rows[0];
                    row["Name"] = s.Name;
                    row["Address"] = s.Address;
                    int rowsAffected = adapter.Update(dt);

                    return rowsAffected > 0; 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp với ID: " + s.Id, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex; 
            }
            finally
            {
                DisConnect(); 
            }
        }


    }
}
