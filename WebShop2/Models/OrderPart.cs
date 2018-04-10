namespace WebShop2.Models
{
    public class OrderPart
    {
        public int Id { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}