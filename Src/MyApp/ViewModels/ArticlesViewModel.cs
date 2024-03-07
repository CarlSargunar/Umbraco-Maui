using CommunityToolkit.Mvvm.Input;
using MyApp.Models;
using MyApp.Services;
using MyApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public partial class ArticlesViewModel : BaseViewModel
    {
        // An observable collection will notify the UI when items are added or removed
        public ObservableCollection<Article> Articles { get; } = new();
        ContentDeliveryService _contentDeliveryService;
        IConnectivity _connectivity;

        public ArticlesViewModel(ContentDeliveryService contentDeliveryService, IConnectivity connectivity)
        {
            Title = "Articles";
            _contentDeliveryService = contentDeliveryService;
            _connectivity = connectivity;
        }

        [RelayCommand]
        async Task GoToDetails(Article article)
        {
            if (article == null)
                return;

            await Shell.Current.GoToAsync(nameof(ArticleDetail), true, new Dictionary<string, object>
            {
                {"Article", article}
            });
        }

        [RelayCommand]
        async Task GetArticles()
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
                var articles = await _contentDeliveryService.GetArticles();

                if (Articles.Count != 0)
                    Articles.Clear();

                foreach (var product in articles)
                    Articles.Add(product);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get articles: {ex.Message}");
                // Hacky way of showing an error - relax, it's a demo
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
