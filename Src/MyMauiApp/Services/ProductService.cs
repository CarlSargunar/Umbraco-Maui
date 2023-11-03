﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MyMauiApp.Helpers;
using MyMauiApp.Models;
using MyMauiApp.Services.Models;

namespace MyMauiApp.Services
{
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
}
