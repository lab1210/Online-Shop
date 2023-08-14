using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Resources
{
    public class ProductResource
    {
       
        [Required]

        public string Name { get; set; }
        [Required]

        public decimal price { get; set; } = 0;
        public decimal? Discount_Price { get; set; }
        [Required]

        public string SKU { get; set; }
        [Required]

        public int CategoryID { get; set; }
        [Required]

        public int SupplierID { get; set; }

        public string imagepath { get; set; }
        public int stock { get; set; }
        public string slug { get; set; }

        public HttpPostedFileBase image { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public string description { get; set; }

    }
}