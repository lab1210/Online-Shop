using Online_Shopping.Migrations;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping.IService
{
    public interface ICartService
    {
        void DeleteItemFromCartaftersale(string user);

        void DeleteItemFromCart(int id);
        void Deletefromroute(int id);

        int GetItemCount(string username);
        int GetHighPurchaseCount();
        int GetLowPurchaseCount();

        int GetPurchaseCount();
        int GetSalesCount();
        decimal GetSalesSum();
        decimal GetPurchaseSum();
        int GetOutOfStockCount();
        IEnumerable<Cart> GetCartByUser(string user);
        IEnumerable<Sale> GetSaleByUser(string user);

        OnRoute Getroute(int id);

        void MakeSales(IEnumerable<Sale> sale);
        void AddSales(SalesInfo salesInfo);

        IEnumerable<Sale> GetAllSales();
        void AddTodriverList(OnRoute route);
        SalesInfo GetSale(int id);

        void CompleteSales(VerifiedSale verifiedSale);
        IEnumerable<SalesInfo> getsale();
        IEnumerable<Sale> getverifiedsales();
        IEnumerable<Sale> getLowsales();
        IEnumerable<Sale> getHighSales();

        decimal? GetTotal(string username);

        void AbortDelivery(AbortedDeleveries abortedDeleveries);
        IEnumerable<VerifiedSale> verifiedSales();
        IEnumerable<AbortedDeleveries> GetAbortedDeleveries();

        void AddToCart(Cart cart);
        IEnumerable<Cart> GetCartItems(string name);

    }
}
