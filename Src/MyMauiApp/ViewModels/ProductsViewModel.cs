using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Services;
using MyMauiApp.Views;

namespace MyMauiApp.ViewModels;

public partial class ProductsViewModel : BaseViewModel
{
    // An observable collection will notify the UI when items are added or removed
    public ObservableCollection<Product> Products { get; } = new();

    ProductService _productService;
    IConnectivity _connectivity;

    public ProductsViewModel(ProductService productService, IConnectivity connectivity)
    {
        Title = "Maui Shop";
        _productService = productService;
        _connectivity = connectivity;
    }


    [RelayCommand]
    async Task GoToDetails(Product product)
    {
        if (product == null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
        {
            {"Product", product }
        });
    }



    [RelayCommand]
    async Task GetProductFromContentDelivery()
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
            var newProducts = await _productService.GetProductsFromContentDelivery();

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
}