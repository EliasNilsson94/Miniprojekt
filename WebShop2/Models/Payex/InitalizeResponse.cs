using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop2.Models.Payex
{
    public class InitalizeResponse
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public string ParamName { get; set; }

        public string RedirectURL { get; set; }

        public string ThirdPartyError { get; set; }

        public string OrderRef { get; set; }
    }
}