namespace StoreAPI.Utils
{
    public class OrderByCategoryResponse
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<string> Colors { get; set; } = new List<string>();
        public List<int> Numbers { get; set; } = new List<int>();
    }
}