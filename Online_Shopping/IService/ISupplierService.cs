using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface ISupplierService
    {
        Supplier AddSupplier(Supplier supplier);
        void DeleteSupplier(int ID);
        IEnumerable<Supplier> GetSuppliers();
        void UpdateSupplier(Supplier Supplier);
        Supplier GetSupplierByID (int id);


    }
}
