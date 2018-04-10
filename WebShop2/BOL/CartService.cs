using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.DAL;
using WebShop2.Models;

namespace WebShop2.BOL
{
    public class CartService
    {
        public CartProvider CartProvider { get; set; }

        public CartService()
        {
            CartProvider = new CartProvider();
        }

        public Cart addProductToCart(Product product, int id)
        {
            if (CartProvider.GetCartByCustomerId(id) != null)
            {
                return CartProvider.AddProductToCart(product, id);    
            } else
            {
                return CreateCart(product, id);
            }
        }

        internal static long calculateCartPrice(Cart cart)
        {
            decimal cartPrice = 0;
            foreach (var item in cart.OrderParts)
            {
                cartPrice += item.Quantity * item.Product.price;
            }

            return Convert.ToInt64(cartPrice) * 100;
        }

        public Cart GetCartById(int id)
        {
            return CartProvider.GetCartById(id);
        }

        internal void DeleteCartItem(int itemId)
        {
            CartProvider.DeleteCartItem(itemId);
        }

        public Cart GetCartByCustomerId(int id)
        {
            return CartProvider.GetCartByCustomerId(id);
        }

        internal void DeleteCart(int id)
        {
            CartProvider.DeleteCart(id);
        }

        public Cart CreateCart(Product product, int customerId)
        {

            var cart = new Cart
            {
                CustomerID = customerId,
                OrderParts = new List<OrderPart>()
            };

            cart.OrderParts.Add(new OrderPart()
            {
                ProductID = product.Id,
                Quantity = 1
            });

            return CartProvider.CreateCart(cart);

        }
    }
}