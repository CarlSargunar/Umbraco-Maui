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
    public partial class PodcastsViewModel : BaseViewModel
    {
        // An observable collection will notify the UI when items are added or removed
        public ObservableCollection<Podcast> Podcasts { get; } = new();
        ContentDeliveryService _contentDeliveryService;
        IConnectivity _connectivity;

        public PodcastsViewModel(ContentDeliveryService contentDeliveryService, IConnectivity connectivity)
        {
            Title = "Podcasts";
            _contentDeliveryService = contentDeliveryService;
            _connectivity = connectivity;
        }

        [RelayCommand]
        async Task GoToDetails(Podcast podcast)
        {
            if (podcast == null)
                return;

            await Shell.Current.GoToAsync(nameof(PodcastDetail), true, new Dictionary<string, object>
            {
                {"Podcast", podcast}
            });
        }

        [RelayCommand]
        async Task GetPodcasts()
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
                var Podcasts = await _contentDeliveryService.GetPodcasts();

                if (Podcasts.Count != 0)
                    Podcasts.Clear();

                foreach (var product in Podcasts)
                    Podcasts.Add(product);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Podcasts: {ex.Message}");
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
