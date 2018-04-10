using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop2.Models.Payex
{
    public class PayexCompleteResponse
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public string TransactionStatus { get; set; }

        public string TransactionNumber { get; set; }

        public string TransactionRef { get; set; }
        public string OrderID { get; set; }
    }
}