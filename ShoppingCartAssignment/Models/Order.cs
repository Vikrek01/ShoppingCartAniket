using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCartAssignment.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime datetime { get; set; }
        public int Total { get; set; }
        public Guid PId { get; set; }
        public int ID { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }




    }
}