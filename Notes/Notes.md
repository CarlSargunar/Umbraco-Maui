# URLs for Demo

Calling 

- https://localhost:44320/umbraco/swagger
- https://localhost:44320/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct&skip=0&take=10

- https://docs.umbraco.com/umbraco-cms/reference/content-delivery-api

- https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct
- https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Ablogpost
- https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aperson

- https://maui.carlcod.es/umbraco/api/product/getallproducts
- https://maui.carlcod.es/umbraco/api/person/getallpeople
- https://maui.carlcod.es/umbraco/api/blog/getallblogposts


- Author Expand
- https://localhost:44320/umbraco/delivery/api/v1/content?filter=contentType%3Ablogpost&skip=0&take=10&expand=property%3Aauthor

- https://localhost:44320/umbraco/delivery/api/v1/content?filter=contentType%3Ablogpost&skip=0&take=10


- https://localhost:44315/umbraco/delivery/api/v1/content/item/262beb70-53a6-49b8-9e98-cfde2e85a78e

Will return the json from [ProductResponse.json](./ProductResponse.json)

CommunityToolkit.Mvvm

## Product Service

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

## Json Definition

Open Postman and get the response of calling the Product Content Delivery API

    https://maui.carlcod.es/umbraco/delivery/api/v1/content?filter=contentType%3Aproduct

    Paste as Json in Services/Models/ContentDeliveryResponse.cs

    - Rename RootObject to ContentDeliveryResponse
    - Rename Item1 to ContentItem
    - Rename Properties1 to ContentProperties
    - Rename Properties2 to PhotoProperties