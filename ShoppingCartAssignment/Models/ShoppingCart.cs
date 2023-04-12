using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartAssignment.Models
{
    public class ShoppingCart
    {
        public string ItemId { get; set; }
        public decimal quantity { get; set; }
        public decimal Price { get; set; }
        public string Total { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }


    }
}