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
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Supplier", cn);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds);  

                DataRow newRow = ds.Tables[0].NewRow();  
                newRow["Id"] = s.Id;
                newRow["Name"] = s.Name;
                newRow["Address"] = s.Address;
                ds.Tables[0].Rows.Add(newRow); 

                int rowsAffected = adapter.Update(ds.Tables[0]);  
                return rowsAffected > 0;
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
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Supplier WHERE Id = @id", cn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", s.Id);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds); 

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0]; 
                    row["Name"] = s.Name;
                    row["Address"] = s.Address;

                    int rowsAffected = adapter.Update(ds.Tables[0]);  
                    return rowsAffected > 0;
                }
                return false;
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
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Supplier WHERE Id = @id", cn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", id);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds); 

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[0].Delete();  // Xóa dòng
                    int rowsAffected = adapter.Update(ds.Tables[0]);  
                    return rowsAffected > 0;
                }
                return false;
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
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Supplier WHERE Id = @id", cn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", s.Id);
                SqlCommandBuilder cb = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds); 

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];  
                    row["Name"] = s.Name;  
                    row["Address"] = s.Address;  

                    int rowsAffected = adapter.Update(ds.Tables[0]);  
                    return rowsAffected > 0;  
                }
                return false;  
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
