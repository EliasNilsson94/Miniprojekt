using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.DAL;
using WebShop2.Models;

namespace WebShop2.BOL
{
    public class UserService
    {
        private const string CustomerCookieName = "CustomerId";

        public UserProvider UserProvider { get; set; }
        public UserService()
        {
            UserProvider = new UserProvider();
        }
        public Customer GetCurrentCustomer()
        {
            var customerCookie = GetCustomerCookie();

            if (customerCookie == null || string.IsNullOrEmpty(customerCookie.Value))
            {
                var customer = CreateCustomer();

                //sätt cookie
                var newCustomerCookie = new HttpCookie(CustomerCookieName)
                {
                    Value = customer.Id.ToString(), 
                    Expires = new DateTime(2035, 12, 12) 
                };
                HttpContext.Current.Response.Cookies.Add(newCustomerCookie);

                // returnera den skapade användaren
                return customer;
            }
            else
            {
                var customerString = customerCookie.Value;

                int customerId;
                int.TryParse(customerString, out customerId);

                // hämta användaren
                var customer = GetCustomerById(customerId);

                //validera att vi fått en användare
                if (customer == null)
                {
                    // skapa en användare om den inte finns
                    customer = CreateCustomer();
                }

                // returnera användaren
                return customer;
            }
        }

        protected virtual HttpCookie GetCustomerCookie()
        {
            if (HttpContext.Current == null)
                return null;

            if (HttpContext.Current.Request == null)
                return null;

            if (HttpContext.Current.Request.Cookies == null)
                return null;

            return HttpContext.Current.Request.Cookies[CustomerCookieName];
        }

        protected virtual Customer CreateCustomer()
        {

            var cust = new Customer
            {
                FirstName = "Elias",
                LastName = "Nilsson",
                Adress = new Adress
                {
                    City = "Järna",
                    PostalCode = "15330",
                    StreetAdress = "Ängsgatan 10"
                }
            };

            return UserProvider.CreateCutomer(cust);
        }

        protected virtual Customer GetCustomerById(int id)
        {
            // Anropa DAL som i sin tur hämtar användare från DB

            return UserProvider.getCustomerById(id);
        }
    }
}