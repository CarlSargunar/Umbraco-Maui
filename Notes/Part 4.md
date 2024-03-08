# Runthrough - Part 4


1 - Add the following to ProductService.cs


    public async Task<List<Product>> GetProductsFromRest()
    {
        // Load Products from from the Content Custom Rest API
        productList = await FetchProductsFromRestApi();
        return productList;
    }

    /// <summary>
    /// Call the Custom Rest API to load products
    /// </summary>
    /// <returns></returns>
    private async Task<List<Product>> FetchProductsFromRestApi()
    {
        var products = new List<Product>();
        ContentDeliveryResponse contentDeliveryResponse;

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

2 - Update ProductsViewModel.cs with the following code


    [RelayCommand]
    async Task GetProductFromRest()
    {
        if (IsBusy)
            return;

        try
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No connectivity!",
                    $"Please check internet and try again.", "OK");
                return;
            }

            IsBusy = true;
            var newProducts = await _productService.GetProductsFromRest();

            if (Products.Count != 0)
                Products.Clear();

            foreach (var product in newProducts)
                Products.Add(product);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get products: {ex.Message}");
            // Hacky way of showing an error - relax, it's a demo
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }


3 - Update MainPage.xaml.cs with the following code

        <Button Text="Get Products From Rest" 
                Command="{Binding GetProductFromRestCommand}"
                IsEnabled="{Binding IsNotBusy}"
                Margin="8"/>