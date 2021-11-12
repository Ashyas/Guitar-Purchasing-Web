using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Order
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Order id must be 4 digits!")]
        public int oid { get; set; }
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Product id must be 4 digits!")]
        public int pid { get; set; }
        public string email { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1}$", ErrorMessage = "Quantity can be between 1-9!")]
        public int qunt { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MM yyyy}")]
        public string date { get; set; }
        public bool supply { get; set; }
    }
}