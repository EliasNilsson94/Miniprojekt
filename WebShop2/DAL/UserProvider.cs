using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.Models;

namespace WebShop2.DAL
{
    public class UserProvider
    {
        WebShopDb db = new WebShopDb();

        internal Customer CreateCutomer(Customer cust)
        {
            var customer = db.Customer.Add(cust);
            db.SaveChanges();
            return customer;
        }

        public Customer getCustomerById(int id)
        {
            var customer = db.Customer.Find(id);

            return customer;
        }
    }
}