using MyMauiApp.Models;
using MyMauiApp.Services;

namespace MyMauiApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var productService = Application.Current.MainPage
			.Handler
			.MauiContext
			.Services
			.GetService<ProductService>();

		var products = await productService.GetProducts();

		ProductList.ItemsSource = products;
	}

	private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		var product = e.Item as Product;
		Navigation.PushAsync(new DetailPage(product));
	}
}
