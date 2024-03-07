namespace MyApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ArticleButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ArticleList());
    }

    private async void PodcastButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PodcastList());
    }
}