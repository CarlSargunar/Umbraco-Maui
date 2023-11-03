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
			// Load Products from from the Content Delivery API
			// var productList = await FetchProductsFromContentDeliveryApi();
			var productList = await FetchLocalProducts();
			return productList;
		}

		/// <summary>
		/// Load hard coded products
		/// </summary>
		/// <returns></returns>
		private async Task<List<Product>> FetchLocalProducts()
		{
			var productList = new List<Product>();
			var prod1 = new Product
			{
				Name = "Product 1",
				Price = 10.99m,
				Sku = "SKU1",
				Image = "https://picsum.photos/id/101/200",
				Description = "Product 1 Description",
				Category = new string[] { "Category 1", "Category 2" }
			};
			productList.Add(prod1);

			var prod2 = new Product
			{
				Name = "Product 2",
				Price = 20.99m,
				Sku = "SKU2",
				Image = "https://picsum.photos/id/102/200",
				Description = "Product 2 Description",
				Category = new string[] { "Category 1", "Category 2" }
			};
			productList.Add(prod2);

			var prod3 = new Product
			{
				Name = "Product 3",
				Price = 30.99m,
				Sku = "SKU3",
				Image = "https://picsum.photos/id/103/200",
				Description = "Product 3 Description",
				Category = new string[] { "Category 1", "Category 2" }
			};
			productList.Add(prod3);

			return productList;
		}


		/// <summary>
		/// Call the Content Delivery API to load products
		/// </summary>
		/// <returns></returns>
		private async Task<List<Product>> FetchProductsFromContentDeliveryApi()
		{
			throw new NotImplementedException();
		}



		public async Task<List<Product>> GetProductsFromRest()
		{
			// Load Products from from the Content Custom Rest API
			var productList = await FetchProductsFromRestApi();
			return productList;
		}

		/// <summary>
		/// Call the Custom Rest API to load products
		/// </summary>
		/// <returns></returns>
		private async Task<List<Product>> FetchProductsFromRestApi()
		{
			var products = new List<Product>();

			var apiResponse = await httpClient.GetAsync(DemoHelpers.ApiUrl);
			if (apiResponse.IsSuccessStatusCode)
			{
				var restProducts = await apiResponse.Content.ReadFromJsonAsync<List<Product>>();
				foreach (var item in restProducts)
				{
					item.Image = DemoHelpers.ImagePath(item.Image);
					products.Add(item);
				}
			}

			return products;
		}

	}
}
