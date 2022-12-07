namespace StoreAPI.Utils
{
    public class OrderDetailsResponse
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string StatusOrder { get; set; } = string.Empty;
        public List<OrderDetailsProductResponse> Products { get; set; } = new List<OrderDetailsProductResponse>();
    }
}