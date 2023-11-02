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
}