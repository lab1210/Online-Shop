using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface IPurchaseService
    {
        bool AddPurchase(PurchaseResource purchaseResource);
        IEnumerable<PurchaseResource> GetAllPurchases();
        PurchaseResource GetProducts();
        PurchaseResource GetPurchaseByID(int Id);
        IEnumerable<suppliermemo> GetSupplier();

    }
}
