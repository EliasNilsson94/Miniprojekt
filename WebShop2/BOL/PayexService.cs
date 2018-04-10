using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebShop2.DAL;
using WebShop2.Extensions;
using WebShop2.Models;
using WebShop2.Models.Payex;

namespace WebShop2.BOL
{
    public class PayexService
    {
        public PayexProvider PayexProvider { get; set; }

        public PayexService()
        {
            PayexProvider = new PayexProvider();
        }
        public InitalizeResponse initialize8(Cart cart)
        {
            var init = cart.ToPayexInitialize();
            return PayexProvider.Initialize8(init);
        }

        public PayexCompleteResponse Complete(string orderRef)
        {
            return PayexProvider.Complete(orderRef);
        }

        public bool IsTrasactionSuccessfull(PayexCompleteResponse response)
        {
            int status = Convert.ToInt32(response.TransactionStatus);
            if (status == 0 || status == 3 || status == 6)
            {
                return true; 
            }
            else
            {
                return false;
            }
        }
    }
}