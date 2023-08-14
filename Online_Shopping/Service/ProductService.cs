using Online_Shopping.IService;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_Shopping.Service
{
    public class ProductService : IProductService
    {
        private readonly ShoppingContext shoppingContext;
        public ProductService()
        {

            shoppingContext = new ShoppingContext();
        }


        public Product SaveProduct(Product product)
        {
            product.Slug = $"{product.SKU}-{product.Name}".ToLower().Replace(" ", "-");


            shoppingContext.Products.Add(product);
            shoppingContext.SaveChanges();
            return product;
        }

        public IEnumerable<ProductResource> GetAllProducts()
        {

            var list = shoppingContext.Products
                .Include(c => c.Category)
                .Include(c => c.Supplier).ToList();
            var productres = new List<ProductResource>();
            foreach (var product in list)
            {
                var purchasedQuantity = shoppingContext.PurchaseProducts
                   .Where(p => p.ProductID == product.Id)
                   .Sum(p => (int?)p.Quantity) ?? 0;

                var soldQuantity = shoppingContext.SalesCart
                     .Where(p => p.Name == product.Name)
                     .Sum(p => (int?)p.Quantity) ?? 0;

                int stock = purchasedQuantity - soldQuantity;
                if (stock < 0)
                {
                    stock = 0;
                }

                var productresource = new ProductResource()
                {
                    Name = product.Name,
                    SKU = product.SKU,
                    imagepath = product.imagepath,
                    price = product.price,
                    Discount_Price = product.Discount_Price,
                    SupplierID = product.SupplierID,
                    CategoryID = product.CategoryID,
                    Supplier = product.Supplier,
                    Category = product.Category,
                    slug = product.Slug,
                    description = product.description,
                    stock = stock,


                };
                var existingreport = shoppingContext.productReports.FirstOrDefault(r => r.ProductID == product.Id);
                if (existingreport == null)
                {
                    var reports = new ProductReport
                    {
                        ProductID = product.Id,
                        Name = product.Name,
                        InStockQuantity = stock,
                        imagepath = product.imagepath,
                        slug = product.Slug
                    };
                    shoppingContext.productReports.Add(reports);
                }
                else
                {
                    existingreport.InStockQuantity = stock;
                }
                shoppingContext.SaveChanges();

                productres.Add(productresource);
            }
            return productres;
        }

        public void DeleteProduct(string slug)
        {
            var product = shoppingContext.Products.FirstOrDefault(c => c.Slug == slug);
            shoppingContext.Products.Remove(product);
            shoppingContext.SaveChanges();

        }
        public void UpdateProduct(ProductResource product)
        {
            var existing = shoppingContext.Products.FirstOrDefault(c => c.Slug == product.slug);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.SKU = product.SKU;
                existing.imagepath = product.imagepath;
                existing.price = product.price;
                existing.Discount_Price = product.Discount_Price;
                existing.CategoryID = product.CategoryID;
                existing.SupplierID = product.SupplierID;
                existing.Slug = product.slug;
                existing.description = product.description;
                shoppingContext.SaveChanges();
            }

        }
        public ProductResource GetProductBySlug(string slug)
        {
            var product = shoppingContext.Products
                .FirstOrDefault(p => p.Slug == slug);
            if (product != null)
            {
                var productresource = new ProductResource
                {
                    Name = product.Name,
                    SKU = product.SKU,
                    imagepath = product.imagepath,
                    price = product.price,
                    Discount_Price = product.Discount_Price,
                    CategoryID = product.CategoryID,
                    SupplierID = product.SupplierID,
                    slug = product.Slug,
                    description = product.description,

                };
                return productresource;
            }
            return null;
        }
        public IEnumerable<ProductReport> GetInventory()
        {
            return shoppingContext.productReports.ToList();
        }

        public IEnumerable<ProductReport> Stock()
        {

            var list = shoppingContext.productReports.Where(c => c.InStockQuantity == 0).OrderBy(c => c.Name);
            return list;
        }
        public IEnumerable<ProductResource> GetRelatedProductsByCategory(int categoryId)
        {
            var relatedProducts = shoppingContext.Products.Where(p => p.CategoryID == categoryId).ToList()
                                        .Select(p => new ProductResource
                                        {
                                            imagepath = p.imagepath,
                                            price = p.price,
                                            Name = p.Name,
                                            SKU = p.SKU,
                                            Discount_Price = p.Discount_Price,
                                            slug = p.Slug,
                                        });
            return relatedProducts;
        }
      

        public IEnumerable<ProductResource> ProductSearch(string searchname)
        {

            var list = shoppingContext.Products
                .Include(c => c.Category)
                .Include(c => c.Supplier)
                .Where(c => c.Name.ToLower().Contains(searchname.ToLower()))
                .ToList();
            var productres = new List<ProductResource>();
            foreach (var product in list)
            {
                var purchasedQuantity = shoppingContext.PurchaseProducts
                   .Where(p => p.ProductID == product.Id)
                   .Sum(p => (int?)p.Quantity) ?? 0;

                var soldQuantity = shoppingContext.SalesCart
                    .Where(p => p.Name == product.Name)
                    .Sum(p => (int?)p.Quantity) ?? 0;
                int stock = purchasedQuantity - soldQuantity;
                if (stock < 0)
                {
                    stock = 0;
                }

                var productresource = new ProductResource()
                {
                    Name = product.Name,
                    SKU = product.SKU,
                    imagepath = product.imagepath,
                    price = product.price,
                    Discount_Price = product.Discount_Price,
                    SupplierID = product.SupplierID,
                    CategoryID = product.CategoryID,
                    Supplier = product.Supplier,
                    Category = product.Category,
                    slug = product.Slug,
                    description = product.description,
                    stock = stock,


                };
                var existingreport = shoppingContext.productReports.FirstOrDefault(r => r.ProductID == product.Id);
                if (existingreport == null)
                {
                    var reports = new ProductReport
                    {
                        ProductID = product.Id,
                        Name = product.Name,
                        InStockQuantity = stock,
                        imagepath = product.imagepath,
                        slug = product.Slug
                    };
                    shoppingContext.productReports.Add(reports);
                }
                else
                {
                    existingreport.InStockQuantity = stock;
                }
                shoppingContext.SaveChanges();

                productres.Add(productresource);
            }
            return productres;
        }

       
    }
}