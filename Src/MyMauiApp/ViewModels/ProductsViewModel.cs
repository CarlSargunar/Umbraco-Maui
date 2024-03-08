using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using MyMauiApp.Models;
using MyMauiApp.Services;
using MyMauiApp.Views;
using Plugin.LocalNotification;

namespace MyMauiApp.ViewModels
{
	public partial class ProductsViewModel : BaseViewModel
	{
		// An observable collection will notify the UI when items are added or removed
		public ObservableCollection<Product> Products { get; } = new();

		ProductService _productService;
        NotificationService _notificationService;
        IConnectivity _connectivity;
        private bool isPolling;
        private readonly TimeSpan pollingInterval = TimeSpan.FromSeconds(5);

        public ProductsViewModel(ProductService productService, IConnectivity connectivity, NotificationService notificationService)
		{
			Title = "Maui Shop";
			_productService = productService;
			_connectivity = connectivity;
			_notificationService = notificationService;
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
		async Task GetProducts()
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
		async Task ToggleNotification()
		{
            if (!isPolling)
            {
                await StartPollingLoopAsync();
            }
            else
            {
                await StopPollingLoopAsync();
            }
        }

        public async Task StartPollingLoopAsync()
        {
            isPolling = true;

            while (isPolling)
            {
                var message = await _notificationService.StartPollingAsync();

                if (message != null)
                {
                    await Application.Current.MainPage.DisplayAlert("New Article", message.Title, "OK");
					await GetProducts();
                }

                // Wait for the polling interval before checking for new notifications again
                await Task.Delay(pollingInterval);
            }
        }

        public async Task StopPollingLoopAsync()
        {
            isPolling = false;
        }
    }

}

