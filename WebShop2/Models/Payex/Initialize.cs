using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop2.Models.Payex
{
    public class Initialize
    {
        public long AccountNumber { get; set; }
        public string PurchaseOperation { get; set; }

        public long Price { get; set; }

        public string PriceArgList = "";

        public string Currency { get; set; }

        public int Vat { get; set; }

        public string OrderId { get; set; }

        public string ProductNumber { get; set; }

        public string Description { get; set; }

        public string ClientIPAddress { get; set; }

        public string ClientIdentifier = "";

        public string AdditionalValues = "RESPONSIVE=1";

        public string ExternalID = "";

        public string ReturnUrl { get; set; }

        public string View { get; set; }

        public string AgreementRef = "";

        public string CancelUrl = "";

        public string ClientLanguage ="";

        public string Hash { get; set; }
    }
}