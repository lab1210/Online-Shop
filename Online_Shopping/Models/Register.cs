using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Shopping.Models
{
    public class Register
    {
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Password should be at least 8 characters long.")]
        public string Password { get; set; }
        [Required]

        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

    }
}