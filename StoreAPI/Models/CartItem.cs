namespace StoreAPI.Models
{
    public class CartItem
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}