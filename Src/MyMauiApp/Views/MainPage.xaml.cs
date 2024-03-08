using MyMauiApp.Models;
using MyMauiApp.Services;
using System.Collections.ObjectModel;
using MyMauiApp.ViewModels;
using Plugin.LocalNotification;
using Azure.Messaging.ServiceBus;
using MyMauiApp.Helpers;
using System.Text.Json;
using System.Text;

namespace MyMauiApp.Views;

public partial class MainPage : ContentPage
{
    private readonly TimeSpan _pollingInterval;

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
			.GetService<ProductService>();

		var products = await productService.GetProducts();
		ProductList.ItemsSource = products;
	}

}
