using MyMauiApp.Models;
using MyMauiApp.Services;
using System.Collections.ObjectModel;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(PodcastsViewModel viewModel)
	{
		// Set the Binding Context on the constructor to hook it all up
		BindingContext = viewModel;
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var podcastService = Application.Current.MainPage
			.Handler
			.MauiContext
			.Services
			.GetService<ContentService>();

		var podcasts = await podcastService.GetPodcasts();

		PodcastList.ItemsSource = podcasts;
	}
}
