namespace StoreAPI.Utils
{
    public class OrderOverviewResponse
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string StatusOrder { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public string Product { get; set; } = string.Empty;
        public string ProductImageUrl { get; set; } = string.Empty;
    }
}