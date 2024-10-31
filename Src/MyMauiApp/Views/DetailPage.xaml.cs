using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class DetailPage : ContentPage
{
    public DetailPage(ProductDetailViewModel productDetailViewModel)
    {
        InitializeComponent();
        BindingContext = productDetailViewModel;
    }
}