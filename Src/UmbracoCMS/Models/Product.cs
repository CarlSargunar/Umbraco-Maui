namespace UmbracoCMS.Models
{
    public class Product : Content
    {
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string[] Category { get; set; }
    }
}
