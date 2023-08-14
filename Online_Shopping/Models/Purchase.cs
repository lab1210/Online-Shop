using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        [Required]

        public DateTime PurchaseDate { get; set; }
        public List<PurchasedProduct> PurchaseProducts { get;set; }
        public string Created_By { get;set; }

    }
    public class PurchasedProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; } = 0;
        public string Name { get; set; }
        [Range(0, double.PositiveInfinity)]

        public int Quantity { get; set; } = 0;
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public string Supplier_Name { get;set; }
    }
}