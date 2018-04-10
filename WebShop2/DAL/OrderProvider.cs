using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.DAL
{
    public class OrderProvider
    {
        WebShopDb db = new WebShopDb();

        public Order addOrder(Order order)
        {
            
                var dbOrder = db.Orders.Add(order);
                db.SaveChanges();
                return dbOrder;
        }

        internal Order getOrderFromId(int id)
        {
            return db.Orders.Find(id);
        }

        internal void addCustomerToOrder(Customer customer, int orderId)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
        }
    }
}