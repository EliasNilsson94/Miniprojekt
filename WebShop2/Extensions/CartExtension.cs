using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.Extensions
{
    public static class CartExtension
    {
        public static Order ToOrder(this Cart cart)
        {
            Order order = new Order();
            order.Customer = new Customer
            {
                FirstName = cart.Customer.FirstName,
                LastName = cart.Customer.LastName,
                Adress = new Adress
                {
                    City = cart.Customer.Adress.City,
                    PostalCode = cart.Customer.Adress.PostalCode,
                    StreetAdress = cart.Customer.Adress.StreetAdress
                }
            };

            order.OrderParts = new List<OrderPart>();
            foreach (OrderPart op in cart.OrderParts)
            {
                order.OrderParts.Add(new OrderPart
                {
                    ProductID = op.ProductID,
                    Quantity = op.Quantity
                    
                });
            }

            return order;
        }
    }
}