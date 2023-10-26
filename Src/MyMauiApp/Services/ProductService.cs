﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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
            if (productList?.Count > 0)
                return productList;

            // We don't have a list of products, so load it from the Product API
            productList = await FetchProductsFromApi();
            return productList;
        }

        private async Task<List<Product>> FetchProductsFromApi()
        {
            // Call the Content Delivery API to load products
            var products = new List<Product>();
            ContentDeliveryResponse contentDeliveryResponse;

            var apiResponse = await httpClient.GetAsync(Helpers.APIURL);
            if (apiResponse.IsSuccessStatusCode)
            {
                contentDeliveryResponse = await apiResponse.Content.ReadFromJsonAsync<ContentDeliveryResponse>();

                foreach (var item in contentDeliveryResponse.items)
                {
                    var product = new Product
                    {
                        Name = item.properties.productName,
                        Price = item.properties.price,
                        SKU = item.properties.sku,
                        Description = item.properties.description,
                        Category = item.properties.category,
                        Image = Helpers.ImagePath(item.properties.photos[0].url)
                    };
                    products.Add(product);
                }
            }

            return products;
        }
    }
}
