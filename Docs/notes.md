# Runthrough

1 - Delete MainPage.Xaml. Add folder Views, and add a new ContentPage (Xaml) called MainPage.Xaml
2 - Modify the shell to include the namespace below, and set the ContentTemplate to MainPage

    xmlns:views="clr-namespace:umbMaui.Views"

3 - Add the Model for Product in the folder Models/Product.cs. Include the context for later

    public class Product
    {
        // Hard coded for demo
        private static readonly CultureInfo CultureInfo = new("en-GB"); 
        public string FormattedPrice => Price.ToString("C2", CultureInfo);

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string[] Category { get; set; }
    }

    [JsonSerializable(typeof(List<Product>))]
    internal sealed partial class ProductContext : JsonSerializerContext
    {

    }

4 - Add a product Service to the file Services/ProductService.cs

    public class ProductService
	{
		public ProductService()
		{
		}

		List<Product> productList;

		public async Task<List<Product>> GetProducts()
		{
			productList = new List<Product>();
			
            var prod1 = new Product
            {
                Name = "Product 1",
                Price = 10.99m,
                Sku = "SKU1",
                Image = "https://via.placeholder.com/150",
                Description = "Product 1 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod1);

            var prod2 = new Product
            {
                Name = "Product 2",
                Price = 20.99m,
                Sku = "SKU2",
                Image = "https://via.placeholder.com/150",
                Description = "Product 2 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod2);

            var prod3 = new Product
            {
                Name = "Product 3",
                Price = 30.99m,
                Sku = "SKU3",
                Image = "https://via.placeholder.com/150",
                Description = "Product 3 Description",
                Category = new string[] { "Category 1", "Category 2" }
            };
            productList.Add(prod3);

			return productList;
		}
	
	}

5 - Set up the service, as well as the main Page in the MauiProgram.cs

    builder.Services.AddTransient<ProductService>();

## URLs

Calling 

    https://localhost:44315/umbraco/delivery/api/v1/content/item/262beb70-53a6-49b8-9e98-cfde2e85a78e

Will return the json from [ProductResponse.json](./ProductResponse.json)