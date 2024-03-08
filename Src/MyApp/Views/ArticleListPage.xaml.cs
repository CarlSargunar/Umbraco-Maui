using MyApp.Services;
using MyApp.ViewModels;

namespace MyApp.Views;

public partial class ArticleListPage : ContentPage
{
	public ArticleListPage(ArticlesViewModel? articlesViewModel)
	{
		BindingContext = articlesViewModel;
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var contentService = Application.Current.MainPage
            .Handler
            .MauiContext
            .Services
            .GetService<ContentDeliveryService>();

        var articles = await contentService.GetArticles();

        ArticleList.ItemsSource = articles;
    }

}