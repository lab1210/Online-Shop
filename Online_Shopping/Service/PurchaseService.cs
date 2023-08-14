using Online_Shopping.IService;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Online_Shopping.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ShoppingContext _context;
        public PurchaseService()
        {
            _context = new ShoppingContext();
        }

        public bool AddPurchase(PurchaseResource purchaseResource)
        {
            var product = purchaseResource.PurchasedProductResources;
            product = product.Where(c => (c.Price > 0) && (c.Quantity > 0)).ToList();
            var NewPurchase = new Purchase()
            {
                PurchaseDate = DateTime.Now,
                SupplierID = purchaseResource.SupplierID,
                Created_By = purchaseResource.Created_By,

            };
            var purchaseprod = new List<PurchasedProduct>();
            decimal total = 0;
            foreach (var item in product)
            {
                var purchase = new PurchasedProduct();

                purchase.Price = item.Price;
                purchase.Quantity = item.Quantity;
                purchase.ProductID = item.ProductID;
                purchase.Name = item.Name;
                    
                total += (decimal)purchase.Price * purchase.Quantity;

                purchaseprod.Add(purchase);
            }
            NewPurchase.Total = total;
            NewPurchase.PurchaseProducts = purchaseprod;
            _context.Purchases.Add(NewPurchase);
            _context.SaveChanges();
            return true;

        }
        public IEnumerable<PurchaseResource> GetAllPurchases()
        {
            var purchases = _context.Purchases.Include(p => p.Supplier).ToList();
            var purchaseResourcesList = new List<PurchaseResource>();

            foreach (var purchase in purchases)
            {

                var purchaseResource = new PurchaseResource
                {
                    Total = purchase.Total,
                    PurchaseDate = purchase.PurchaseDate,
                    Supplier = purchase.Supplier,
                    SupplierID = purchase.SupplierID,
                    Created_By = purchase.Created_By,
                    Id = purchase.Id,


                };

                purchaseResourcesList.Add(purchaseResource);
            }

            return purchaseResourcesList;
        }
      
        public PurchaseResource GetProducts()
        {
            var list = new PurchaseResource();
            var products = new List<PurchasedProductResource>();
            var data = _context.Products.OrderBy(o => o.Supplier.Name).ToList();
            foreach (var item in data)
            {
                var product = new PurchasedProductResource
                {
                    Name = item.Name,
                    ProductID = item.Id,
                    Supplier_Name=item.Supplier.Name

                };
                products.Add(product);
            }
            list.PurchasedProductResources = products;

            return list;

        }
       

        public PurchaseResource GetPurchaseByID(int Id)
        {
            var purchase = _context.Purchases.Include(p => p.Supplier)
               .Include(p => p.PurchaseProducts)
               .SingleOrDefault(p => p.Id == Id);
            var purchaseResource = new PurchaseResource
            {
                Id = purchase.Id,
                PurchaseDate = purchase.PurchaseDate,
                Total = purchase.Total,
                SupplierID = purchase.SupplierID,
                Supplier = purchase.Supplier,
                PurchasedProductResources = purchase.PurchaseProducts.Select(p => new PurchasedProductResource
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Price = p.Price,
                }).ToList()
            };
            return purchaseResource;
        }

        public IEnumerable<suppliermemo> GetSupplier()
        {
            var data = _context.Suppliers.OrderBy(o => o.Name).ToList()
                .Select(x => new suppliermemo
                {
                    Id = x.Id,
                    Name = x.Name
                });
            return data;
        }

    }
}