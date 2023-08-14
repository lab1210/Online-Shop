using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z ]+[a-zA-Z ]*$", ErrorMessage = "Name must start with a capital letter and contain only letters")]

        public string Name { get; set; }
        [Required]

        public string Email { get;set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "must contain only digits")]

        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
    public class suppliermemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}