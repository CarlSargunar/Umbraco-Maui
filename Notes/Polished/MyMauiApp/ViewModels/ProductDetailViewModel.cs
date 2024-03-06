using MyMauiApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

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