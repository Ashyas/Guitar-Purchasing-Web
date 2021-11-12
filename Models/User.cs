using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mail address must be at least 10 digits")]
        [RegularExpression("^[a-z0-9]+@[a-z]+[.][a-z]+$", ErrorMessage = "Invalid mail")]
        public string email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password length must be 6-12 characters")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Password characters can be only letters or numbers")]
        public string password { get; set; }

        public bool type { get; set; }
}
}