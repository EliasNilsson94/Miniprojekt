using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.DAL
{
    public class WebShopDb : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<OrderPart> OrderParts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}