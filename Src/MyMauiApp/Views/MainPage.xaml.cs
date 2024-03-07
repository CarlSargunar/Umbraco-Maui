using MyMauiApp.Models;
using MyMauiApp.Services;
using System.Collections.ObjectModel;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ProductsViewModel productsViewModel)
	{
		// Set the Binding Context on the constructor to hook it all up
		BindingContext = productsViewModel;
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var productService = Application.Current.MainPage
			.Handler
			.MauiContext
			.Services
			.GetService<ContentDeliveryService>();

		var products = await productService.GetProducts();

		ProductList.ItemsSource = products;
	}
}
