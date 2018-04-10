using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop2.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string LastName { get; set; }

        public int AdressID { get; set; }
        public virtual Adress Adress { get; set; }
    }
}