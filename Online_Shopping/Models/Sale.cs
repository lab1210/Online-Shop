using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Online_Shopping.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string user { get; set; }
        [Required]

        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;


    }
    public class SalesInfo
    {
        public int Id { get;set; }
        public List<Sale> Sale { get;set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number must contain only digits")]

        public string Phone { get; set; }
        public string user { get;set; }

    }
    public class OnRoute
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public DateTime SaleDate { get; set; }
        public string Driver { get; set; }
        public int SaleCode { get; set; }
    }
    public class VerifiedSale
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public DateTime SaleDate { get; set; }
        public int SaleCode { get; set; }

        public string Driver { get; set; }
    }
    public class AbortedDeleveries
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Customer { get; set; }
        [Required]
        public string Reason { get; set; }
        public string Address { get; set; }
        public DateTime SaleDate { get; set;}
    }
}