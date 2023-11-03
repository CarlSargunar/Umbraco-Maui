using CommunityToolkit.Mvvm.ComponentModel;
using MyMauiApp.Models;
using MyMauiApp.ViewModels;

namespace MyMauiApp.ViewModels;

[QueryProperty(nameof(Product), "Product")]
public partial class ProductDetailViewModel : BaseViewModel
{
	public ProductDetailViewModel()
	{

	}

	[ObservableProperty]
	Product product;
}