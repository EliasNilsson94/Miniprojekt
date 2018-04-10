using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.DAL
{
    public class ProductProvider
    {
        WebShopDb db = new WebShopDb();

        public List<Product> getAllProducts()
        {
            var products = db.Products.ToList();
            return products;
        }

        internal void addProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        internal Product getProduct(int? id)
        {
            return db.Products.Find(id);
        }

        internal void removeProduct(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}