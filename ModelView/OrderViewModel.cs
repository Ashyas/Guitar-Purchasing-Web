using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ModelView
{
    public class OrderViewModel
    {
        public Order order { get; set; }

        public List<Order> Orders { get; set; }
    }
}