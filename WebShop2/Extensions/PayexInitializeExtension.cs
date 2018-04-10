using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WebShop2.App_Start.HelpClasses;
using WebShop2.BOL;
using WebShop2.Models;
using WebShop2.Models.Payex;

namespace WebShop2.Extensions
{
    public static class PayexInitializeExtension
    {
        public static Initialize ToPayexInitialize(this Cart cart)
        {


            long payexAccountNumber =  Convert.ToInt64(ConfigurationManager.AppSettings["PayexAccountNumber"]);
            Initialize init = new Initialize
            {
                AccountNumber = payexAccountNumber,
                PurchaseOperation = "SALE",
                Price = CartService.calculateCartPrice(cart),
                Currency = "SEK",
                Vat = 0,
                OrderId = Guid.NewGuid().ToString().Replace("-", ""),
                ProductNumber = "12345678",
                Description = "Multipleproducts",
                ClientIPAddress = "127.0.0.1",
                ReturnUrl = "http://localhost:59808/Payment/PayexComplete",
                View = "CREDITCARD"
            };

            var key = ConfigurationManager.AppSettings["PayexEncryptionKey"];

            CreateMD5Hash MD5Hash = new CreateMD5Hash(init.AccountNumber +
                init.PurchaseOperation +
                init.Price +
                init.PriceArgList +
                init.Currency +
                init.Vat +
                init.OrderId +
                init.ProductNumber +
                init.Description +
                init.ClientIPAddress +
                init.ClientIdentifier +
                init.AdditionalValues +
                init.ExternalID +
                init.ReturnUrl +
                init.View +
                init.AgreementRef +
                init.CancelUrl +
                init.ClientLanguage +
                key
            );

                init.Hash = MD5Hash.getHash();


            return init;
        }
    }
}