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
            loadArticles();
        }

        [RelayCommand]
        async Task GoToDetails(Article article)
        {
            if (article == null)
                return;

            await Shell.Current.GoToAsync(nameof(ArticleDetailPage), true, new Dictionary<string, object>
            {
                {"Article", article}
            });
        }

        [RelayCommand]
        async Task GetArticles()
        {
            loadArticles();
        }


        private async void loadArticles()
        {
            if (IsBusy)
                return;

            try
            {
                if (_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    Shell.Current.DisplayAlert("No connectivity!",
                                               $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;
                var articles = await _contentDeliveryService.GetArticles();
                Articles.Clear();
                foreach (var article in articles)
                {
                    Articles.Add(article);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Shell.Current.DisplayAlert("Error", "Unable to load articles", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
