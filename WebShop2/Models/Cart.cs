using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop2.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual List<OrderPart> OrderParts { get; set; }
    }
}