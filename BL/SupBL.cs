using DL;
using System;
using System.Data;
using System.Runtime.Remoting.Contexts;
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

        public bool EditSupplier(Sup s)
        {
            return supDL.EditSupplier(s);
        }

        public bool AddSupplier(Sup s)
        {
            return supDL.AddSupplier(s);
        }
        public Sup GetSupplierById(string supplierId)
        {
   
            return supDL.GetSupplierById(supplierId);
        }

    }
}
