using MyMauiApp.ViewModels;

namespace MyMauiApp.Views;

public partial class DetailPage : ContentPage
{
    private PodcastDetailViewModel _viewModel;

	public DetailPage(PodcastDetailViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		BindingContext = viewModel;
	}

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var file = new Uri(_viewModel.Podcast.AudioFile);
            await MediaPlayer.PlayAsync(file);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"Error playing audio: {ex.Message}");
        }
    }
}