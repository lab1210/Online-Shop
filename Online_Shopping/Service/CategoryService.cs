using Online_Shopping.IService;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Online_Shopping.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ShoppingContext _context;
        public CategoryService()
        {
            _context = new ShoppingContext();
        }
        public Category AddCategory(Category category)
        {
            var existing= _context.Categories.FirstOrDefault(c=>c.Name==category.Name);
            if (existing == null)
            {
                Random random = new Random();
                int code = random.Next(1, 10000);
                category.Code = code;
                _context.Categories.Add(category);
                _context.SaveChanges();

                return category;
            }
            else
            {
                throw new Exception( existing.Name +"category already exists");

            }
        }
        public void DeleteCategory(int code)
        {
           var category = _context.Categories.FirstOrDefault(c => c.Id == code);
            _context.Categories.Remove(category);
           
            _context.SaveChanges();
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public IEnumerable<CategoryMemo> GetCategory()
        {
            var data = _context.Categories.OrderBy(o => o.Name).ToList()
                .Select(x => new CategoryMemo
                {
                    id = x.Id,
                    Name = x.Name
                });
            return data;
        }
       public IEnumerable<ProductResource> GetproductbyCategory(int categoryid)
        {
            var list = _context.Products
               .Include(c => c.Category)
               .Include(c => c.Supplier)
               .Where(c => c.CategoryID==categoryid)
               .ToList();
            var productres = new List<ProductResource>();
            foreach (var product in list)
            {
                var purchasedQuantity = _context.PurchaseProducts
                   .Where(p => p.ProductID == product.Id)
                   .Sum(p => (int?)p.Quantity) ?? 0;

                var soldQuantity = _context.SalesCart
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
                var existingreport = _context.productReports.FirstOrDefault(r => r.ProductID == product.Id);
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
                    _context.productReports.Add(reports);
                }
                else
                {
                    existingreport.InStockQuantity = stock;
                }
                _context.SaveChanges();

                productres.Add(productresource);
            }
            return productres;
           
        }
      
    }
}