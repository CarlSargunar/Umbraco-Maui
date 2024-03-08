using MyApp.Services;
using MyApp.ViewModels;

namespace MyApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ArticleButton_Clicked(object sender, EventArgs e)
    {
        var context = Application.Current.MainPage.Handler.MauiContext;
        var contentService = context
            .Services
            .GetService<ContentDeliveryService>();
        var connectivity = context
            .Services
            .GetService<IConnectivity>();

        var articlesViewModel = new ArticlesViewModel(contentService, connectivity);

        await Navigation.PushAsync(new ArticleListPage(articlesViewModel));
    }

    private async void PodcastButton_Clicked(object sender, EventArgs e)
    {
        var context = Application.Current.MainPage.Handler.MauiContext;
        var contentService = context
            .Services
            .GetService<ContentDeliveryService>();
        var connectivity = context
            .Services
            .GetService<IConnectivity>();

        var podcastsViewModel = new PodcastsViewModel(contentService, connectivity);


        await Navigation.PushAsync(new PodcastListPage(podcastsViewModel));
    }
}