using MyApp.Services;
using MyApp.ViewModels;

namespace MyApp.Views;

public partial class PodcastListPage : ContentPage
{
	public PodcastListPage(PodcastsViewModel? podcastsViewModel)
    {
        BindingContext = podcastsViewModel;
        InitializeComponent();
    }

    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();

    //    var contentService = Application.Current.MainPage
    //        .Handler
    //        .MauiContext
    //        .Services
    //        .GetService<ContentDeliveryService>();

    //    var podcasts = await contentService.GetPodcasts();

    //    PodcastList.ItemsSource = podcasts;
    //}
}