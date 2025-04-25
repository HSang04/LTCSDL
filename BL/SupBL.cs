using DL;
using System;
using System.Data;
using TO;

namespace BL
{
    public class SupBL
    {
        private SupDL supDL;

        public SupBL()
        {
            supDL = new SupDL();
        }

        public DataTable GetSuppliers()
        {
            DataSet ds = supDL.GetSuppliers();
            return ds.Tables["Supplier"];
        }

        public bool DeleteSupplier(string id)
        {
            return supDL.DeleteSupplier(id);
        }

        public bool UpdateSupplier(Sup s)
        {
            return supDL.UpdateSupplier(s);
        }

        public bool AddSupplier(Sup s)
        {
            return supDL.AddSupplier(s);
        }
    }
}
