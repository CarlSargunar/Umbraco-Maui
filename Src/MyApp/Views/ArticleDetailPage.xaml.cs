using MyApp.ViewModels;

namespace MyApp.Views;

public partial class ArticleDetailPage : ContentPage
{
	public ArticleDetailPage(ArticleDetailsViewModel articleDetailsViewModel)
	{
		BindingContext = articleDetailsViewModel;
		InitializeComponent();
	}
}