using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop2.Models.Payex
{
    public class PayexComplete
    {
        public long AccountNumber { get; set; }

        public string OrderRef { get; set; }

        public string Hash { get; set; }

    }
}