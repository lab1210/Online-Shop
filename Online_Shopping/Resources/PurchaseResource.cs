using Online_Shopping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Resources
{
    public class PurchaseResource
    {

        public int Id { get; set; }
        public decimal Total { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        [Required]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public List<PurchasedProductResource> PurchasedProductResources { get; set; }
        public string Created_By { get; set; }

    }
    public class PurchasedProductResource
    {

        public int Id { get; set; }
        public decimal Price { get; set; } = 0;
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public int ProductID { get; set; }
        public string Supplier_Name { get; set; }

    }
}