using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Mail address must be at least 10 digits")]
        [RegularExpression("^[a-z0-9]+@[a-z]+[.][a-z]+$", ErrorMessage = "Invalid mail")]
        public string email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be at least 2 digits")]
        public string fname { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be at least 2 digits")]
        public string lname { get; set; }

        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number must be 10 digits")]
        public string phone { get; set; }

    }
}