using System.Globalization;
using System.Text.Json.Serialization;

namespace MyMauiApp.Models
{
    public class Product
    {
        private static readonly CultureInfo _cultureInfo = new("en-GB"); // Hard coded for demo
        public string FormattedPrice => Price.ToString("C2", _cultureInfo);

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string[] Category { get; set; }
    }

    [JsonSerializable(typeof(List<Product>))]
    internal sealed partial class ProductContext : JsonSerializerContext
    {

    }
}
