using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.DAL
{
    public class CartProvider
    {
        WebShopDb db = new WebShopDb();
        internal Cart AddProductToCart(Product product, int id)
        {
            var cart = GetCartByCustomerId(id);
            cart.OrderParts.Add(new OrderPart
            {
                ProductID = product.Id,
                Quantity = 1
            });
            db.SaveChanges();
            return cart;
        }

        internal Cart GetCartByCustomerId(int id)
        {
            var cart = db.Carts.Where(c => c.CustomerID == id)
                .SingleOrDefault();
            
            return cart;
        }

        internal Cart GetCartById(int id)
        {
            var cart = db.Carts.Find(id);

            return cart;
            
        }


        internal void DeleteCartItem(int itemId)
        {
            var orderPart = db.OrderParts.Find(itemId);
            db.OrderParts.Remove(orderPart);
            db.SaveChanges();
        }

        internal Cart CreateCart(Cart cart)
        {
            var customerCart = db.Carts.Add(cart);
            db.SaveChanges();
            return customerCart;
        }

        internal void DeleteCart(int id)
        {

            var cart = db.Carts.Find(id);

            db.OrderParts.RemoveRange(cart.OrderParts);

            db.Carts.Remove(cart);
            db.SaveChanges();
        }

    }
}