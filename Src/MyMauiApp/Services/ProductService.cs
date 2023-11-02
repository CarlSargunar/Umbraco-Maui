using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMauiApp.Models;

namespace MyMauiApp.Services
{
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

	}
}
