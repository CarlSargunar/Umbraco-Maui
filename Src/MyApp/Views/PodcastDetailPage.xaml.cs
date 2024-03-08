using MyApp.ViewModels;

namespace MyApp.Views;

public partial class PodcastDetailPage : ContentPage
{
	public PodcastDetailPage(PodcastDetailsViewModel podcastDetailsViewModel)
	{
		BindingContext = podcastDetailsViewModel;
		Title = podcastDetailsViewModel.Podcast.Name;
		InitializeComponent();
	}
}