using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class ShoppingContext:DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set;}
        public DbSet<PurchasedProduct> PurchaseProducts { get; set; }
        public DbSet<ProductReport> productReports { get; set; }
        public DbSet<OnRoute> onRoutes { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Cart> SalesCart { get; set; }

        public DbSet<VerifiedSale> verifiedSales { get; set; }
        public DbSet<SalesInfo> SalesInfos { get; set; }

        public DbSet<AbortedDeleveries> abortedDeleveries { get; set; }








    }
}