using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCartAssignment.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=MyConnectionString")
        {
        }
        public DbSet<Product> Products { get; set; }
  
        public DbSet<User> Users { get; set; }

    }
}