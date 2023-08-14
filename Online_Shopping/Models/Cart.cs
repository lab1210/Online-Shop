using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string slug { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get;set; }
        public decimal Total { get; set; }
    }
}