using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Code { get; set; }

    }
    public class CategoryMemo
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}