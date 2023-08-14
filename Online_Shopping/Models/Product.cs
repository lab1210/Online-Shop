using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public decimal price { get; set; } = 0;

        public decimal? Discount_Price { get; set; } 
        [Required]

        public string SKU { get;set; }
        [Required]

        public int CategoryID { get;set; }
        public Category Category { get; set; }
        [Required]

        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }

        [Required]

        public string imagepath { get;set; }
        public string Slug { get; set; }
        public string description { get; set; }
        public int stock { get;set; }

    }
    public class ProductReport
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int InStockQuantity { get; set; }
        public string imagepath { get;set; }
        public string slug { get;set; }
    }
}