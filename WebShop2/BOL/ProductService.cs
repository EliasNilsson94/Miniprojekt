using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.DAL;
using WebShop2.Models;

namespace WebShop2.BOL
{
    public class ProductService
    {
        public ProductProvider productProvider { get; set; }

        public ProductService()
        {
            productProvider = new ProductProvider();
        }

        public List<Product> getAllProducts()
        {
            return productProvider.getAllProducts();
        }

        internal void addProduct(Product product)
        {
            productProvider.addProduct(product);
        }

        internal Product getProduct(int? id)
        {
            return productProvider.getProduct(id);
        }

        internal void removeProduct(Product product)
        {
            productProvider.removeProduct(product);
            
        }
    }
}