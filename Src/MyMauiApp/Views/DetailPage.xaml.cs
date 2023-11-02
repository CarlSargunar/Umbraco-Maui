namespace MyMauiApp.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(Models.Product product)
	{
		InitializeComponent();
		BindingContext = product;
	}
}