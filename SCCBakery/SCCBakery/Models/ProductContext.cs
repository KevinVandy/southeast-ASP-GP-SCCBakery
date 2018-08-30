using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("SCCBakery"){}

        //public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
            
    }
}