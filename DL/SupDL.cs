using System;
using System.Data;
using System.Data.SqlClient;
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
    }
}
