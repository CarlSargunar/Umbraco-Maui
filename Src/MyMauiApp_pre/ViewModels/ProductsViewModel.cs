using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Model;
using MyMauiApp.Services;
using MyMauiApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMauiApp.ViewModels
{
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
        async Task GetMonkeysAsync()
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
                var newProducts = await _productService.GetProducts();

                if (Products.Count != 0)
                    Products.Clear();

                foreach (var product in newProducts)
                    Products.Add(product);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                // Hacky way of showing an error
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK"); 
            }
            finally
            {
                IsBusy = false;
            }

        }


    }
}
