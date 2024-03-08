using MyApp.ViewModels;

namespace MyApp.Views;

public partial class PodcastDetailPage : ContentView
{
	public PodcastDetailPage(PodcastDetailsViewModel podcastDetailsViewModel)
	{
		BindingContext = podcastDetailsViewModel;
		InitializeComponent();
	}
}