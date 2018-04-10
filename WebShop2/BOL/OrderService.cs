using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.DAL;
using WebShop2.Models;

namespace WebShop2.BOL
{
    public class OrderService
    {
        public OrderProvider OrderProvider { get; set; }

        public OrderService()
        {
            OrderProvider = new OrderProvider();
        }

        public Order addOrder(Order order)
        {
            return OrderProvider.addOrder(order);
        }

        internal Order getOrderFromId(int id)
        {
           return OrderProvider.getOrderFromId(id);
        }

        public void addCustomerToOrder(Customer customer, int orderId)
        {

            OrderProvider.addCustomerToOrder(customer, orderId);
        }
    }
}