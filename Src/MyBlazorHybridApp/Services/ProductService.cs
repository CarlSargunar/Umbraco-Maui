using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MyMauiApp.Helpers;
using MyMauiApp.Models;

namespace MyMauiApp.Services
{
	public class ProductService
	{

		HttpClient httpClient;
		public ProductService()
		{
			this.httpClient = new HttpClient();
		}
		

		public async Task<List<Product>> GetProducts()
		{
            // Simulate a random delay
            var delay = new Random().Next(500, 2000);
            Thread.Sleep(delay);
			// Load Products from from the Content Delivery API
			var productList = await FetchProductsFromContentDeliveryApi();
			return productList;
		}

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
                        Name = item.name,
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
}
