using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Product
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "ID must be 4 digits")]
        public int pid { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Cake name must be at least 4 digits")]
        public string pname { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$", ErrorMessage = "Price must be between 0-999!")]
        public int price { get; set; }

    }
}