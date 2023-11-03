# Runthrough - Part 3

1 - Open Postman and get the response of calling the Product Content Delivery API

    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct

    Paste as Json in Services/Models/ContentDeliveryResponse.cs

    - Rename RootObject to ContentDeliveryResponse
    - Rename Item1 to ContentItem
    - Rename Properties1 to ContentProperties
    - Rename Properties2 to PhotoProperties

2 - Add the class Helpers/DemoHelpers.cs

    internal static class DemoHelpers
    {
        internal static string BaseUrl = "https://maui.carlcod.es/";
        internal static string ContentDeliveryApiUrl = $"{BaseUrl}umbraco/delivery/api/v1/content?filter=contentType%3Aproduct";
        internal static string ApiUrl = $"{BaseUrl}umbraco/api/product/getallproducts";

		internal static string ImagePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            return $"{BaseUrl}{path}?width=200";
        }


    }

3 - Update ProductService with the following code

	public class ProductService
	{

		HttpClient httpClient;
		public ProductService()
		{
			this.httpClient = new HttpClient();
		}

		List<Product> productList;

		public async Task<List<Product>> GetProducts()
		{
			// Load Products from from the Content Delivery API
			productList = await FetchProductsFromContentDeliveryApi();
			return productList;
		}

		/// <summary>
		/// Call the Content Delivery API to load products
		/// </summary>
		/// <returns></returns>
		private async Task<List<Product>> FetchProductsFromContentDeliveryApi()
		{
			var products = new List<Product>();
			var apiResponse = await httpClient.GetAsync(DemoHelpers.ContentDeliveryApiUrl);
			if (apiResponse.IsSuccessStatusCode)
			{
				var contentDeliveryResponse = await apiResponse.Content.ReadFromJsonAsync<ContentDeliveryResponse>();

				foreach (var item in contentDeliveryResponse.items)
				{
					var product = new Product
					{
						Name = item.properties.productName,
						Price = item.properties.price,
						Sku = item.properties.sku,
						Description = item.properties.description,
						Category = item.properties.category,
						Image = DemoHelpers.ImagePath(item.properties.photos[0].url)
					};
					products.Add(product);
				}
			}

			return products;
		}

	}