using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Login_Date { get;set; }=DateTime.Now;
    }
    public class LoginMemo
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}