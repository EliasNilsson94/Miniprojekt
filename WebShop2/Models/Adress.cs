using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShop2.Models
{
    public class Adress
    {
        public int Id { get; set; }

        [DisplayName("Street")]
        [Required]
        public string StreetAdress { get; set; }

        [DisplayName("Zip code")]
        [Required]
        public string PostalCode { get; set; }


        [Required]
        public string City { get; set; }
    }
}