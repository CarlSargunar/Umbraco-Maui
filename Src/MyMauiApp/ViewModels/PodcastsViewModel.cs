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

namespace MyMauiApp.ViewModels
{
	public partial class PodcastsViewModel : BaseViewModel
	{
		// An observable collection will notify the UI when items are added or removed
		public ObservableCollection<Podcast> Podcasts { get; } = new();

		ContentService _PodcastService;
		IConnectivity _connectivity;

		public PodcastsViewModel(ContentService PodcastService, IConnectivity connectivity)
		{
			Title = "Maui Shop";
			_PodcastService = PodcastService;
			_connectivity = connectivity;
		}

		[RelayCommand]
		async Task GoToDetails(Podcast Podcast)
		{
			if (Podcast == null)
				return;

			await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
			{
				{"Podcast", Podcast }
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
				var newPodcasts = await _PodcastService.GetPodcasts();

				if (Podcasts.Count != 0)
					Podcasts.Clear();

				foreach (var Podcast in newPodcasts)
					Podcasts.Add(Podcast);

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


		[RelayCommand]
		async Task GetPodcastFromRest()
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
				var newPodcasts = await _PodcastService.GetPodcasts();

				if (Podcasts.Count != 0)
					Podcasts.Clear();

				foreach (var Podcast in newPodcasts)
					Podcasts.Add(Podcast);

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

