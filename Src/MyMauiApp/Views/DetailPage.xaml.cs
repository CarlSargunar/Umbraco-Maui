using CommunityToolkit.Maui.Views;
using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(ProductDetailViewModel productDetailViewModel)
	{
        // Set the Binding Context on the constructor to hook it all up
        BindingContext = productDetailViewModel;
		InitializeComponent();
	}

    private void OnBuyButtonClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new BuyPopup());
    }
}