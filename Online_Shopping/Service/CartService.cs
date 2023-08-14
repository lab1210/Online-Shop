using Online_Shopping.IService;
using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Data.Entity;

namespace Online_Shopping.Service
{
    public class CartService : ICartService
    {
        private readonly ShoppingContext _context;
        public CartService()
        {
            _context = new ShoppingContext();
        }



        public void AddToCart(Cart cart)
        {
            decimal total;

            total = cart.Price * cart.Quantity;

            cart.Total = total;
            _context.SalesCart.Add(cart);
            _context.SaveChanges();
        }
        public IEnumerable<Cart> GetCartItems(string name)
        {
            var list = _context.SalesCart.Where(c => c.UserName == name).ToList();
            return list;
        }

        public void DeleteItemFromCartaftersale(string user)
        {
            var cart = _context.SalesCart.Where(c => c.UserName == user).ToList();
            _context.SalesCart.RemoveRange(cart);

            _context.SaveChanges();
        }
        public void DeleteItemFromCart(int id)
        {
            var cart = _context.SalesCart.FirstOrDefault(c => c.Id == id);
            _context.SalesCart.Remove(cart);
            _context.SaveChanges();

        }



        public int GetItemCount(string username)
        {
            var count = _context.SalesCart.Where(c => c.UserName == username).Count();
            return count;
        }
        public decimal? GetTotal(string username)
        {
            decimal? count = _context.SalesCart.Where(c => c.UserName == username).Sum(s => ((decimal?)s.Total));
            return count;
        }
        public void MakeSales(IEnumerable<Sale> sale)
        {
            _context.Sales.AddRange(sale);

            _context.SaveChanges();
        }

        public void AddSales(SalesInfo salesInfo)
        {
            salesInfo.Sale = new List<Sale> { };
            _context.SalesInfos.Add(salesInfo);

            _context.SaveChanges();
        }
        public IEnumerable<Cart> GetCartByUser(string user)
        {
            var list = _context.SalesCart.Where(c => c.UserName == user).ToList();
            return list;
        }
        public IEnumerable<Sale> GetSaleByUser(string user)
        {
            var list = _context.Sales.Where(c => c.user == user).ToList();
            return list;
        }
        public SalesInfo GetSale(int id)
        {
            return _context.SalesInfos.Find(id);
        }
        public IEnumerable<Sale> GetAllSales()
        {
            return _context.Sales.ToList();
        }

        public void AddTodriverList(OnRoute route)
        {
            var existingroute = _context.onRoutes.FirstOrDefault(r => r.SaleCode == route.SaleCode);

            if (existingroute == null)
            {
                _context.onRoutes.Add(route);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Client Package already on route");
            }
        }
        public void CompleteSales(VerifiedSale verifiedSale)
        {
            _context.verifiedSales.Add(verifiedSale);
            _context.SaveChanges();
        }
        public OnRoute Getroute(int id)
        {
            return _context.onRoutes.Find(id);

        }
        public void Deletefromroute(int id)
        {
            var cart = _context.onRoutes.FirstOrDefault(c => c.id == id);
            _context.onRoutes.Remove(cart);

            _context.SaveChanges();
        }


        public IEnumerable<AbortedDeleveries> GetAbortedDeleveries()
        {
            return _context.abortedDeleveries.OrderByDescending(c => c.SaleDate).ToList();
        }
        public IEnumerable<VerifiedSale> verifiedSales()
        {
            return _context.verifiedSales.OrderByDescending(c => c.SaleDate).ToList();
        }

        public IEnumerable<SalesInfo> getsale()
        {
            var verified = _context.verifiedSales.Select(c => c.SaleCode);
            var list = _context.SalesInfos.Where(s => !verified.Any(c => c == s.Id)).Include(c => c.Sale).ToList();

            return list;
        }
        public IEnumerable<Sale> getverifiedsales()
        {
            var verifiedNames = _context.verifiedSales.Select(vs => vs.name).ToList();
            var list = _context.Sales.Where(s => verifiedNames.Any(vn => vn == s.user)).ToList();
            return list;
        }
        public IEnumerable<Sale> getLowsales()
        {
            var lowSalesProducts = _context.Sales
                .GroupBy(s => s.Name)
                .Where(g => g.Sum(s => ((int?)s.Quantity) ?? 0) <= 5)
            .Select(g => g.FirstOrDefault())
            .ToList();

            return lowSalesProducts;
        }

        public IEnumerable<Sale> getHighSales()
        {
            var HigsalesProducts = _context.Sales
                .GroupBy(s => s.Name)
                .Where(g => g.Sum(s => ((int?)s.Quantity) ?? 0) > 5)
                .Select(g => g.FirstOrDefault())
                 .ToList();

            return HigsalesProducts;
        }



        public int GetHighPurchaseCount()
        {
            var HigsalesProducts = _context.Sales
                .GroupBy(s => s.Name)
                .Where(g => g.Sum(s => ((int?)s.Quantity) ?? 0) > 5)
                 .Select(g => g.FirstOrDefault())

            .Count();

            return HigsalesProducts;
        }
        public int GetLowPurchaseCount()
        {
            var lowsalesProducts = _context.Sales
                .GroupBy(s => s.Name)
                .Where(g => g.Sum(s => ((int?)s.Quantity) ?? 0) <= 5)
            .Select(g => g.FirstOrDefault())
            .Count();

            return lowsalesProducts;
        }

        public int GetPurchaseCount()
        {
            var count = _context.Purchases.Count();
            return count;
        }
        public int GetSalesCount()
        {
            var count = _context.Sales.Count();
            return count;
        }

        public int GetOutOfStockCount()
        {
            var list = _context.productReports.OrderByDescending(c=>c.Name).Where(c => c.InStockQuantity == 0).Count();
            return list;
        }
        public decimal GetSalesSum()
        {
            var sum = _context.Sales.Sum(s => ((decimal?)s.Price) ?? 0);
            return sum;
        }
        public decimal GetPurchaseSum()
        {
            var sum = _context.Purchases.Sum(s => ((decimal?)s.Total) ?? 0);
            return sum;

        }
        public void AbortDelivery(AbortedDeleveries abortedDeleveries)
        {
            _context.abortedDeleveries.Add(abortedDeleveries);
            _context.SaveChanges();
        }
    }
}