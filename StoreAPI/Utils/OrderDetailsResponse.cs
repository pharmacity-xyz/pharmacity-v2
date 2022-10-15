namespace StoreAPI.Utils
{
    public class OrderDetailsResponse
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetailsProductResponse> Products { get; set; } = new List<OrderDetailsProductResponse>();
    }
}