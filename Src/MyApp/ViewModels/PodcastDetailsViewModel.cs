using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;

namespace MyApp.ViewModels;

[QueryProperty(nameof(Podcast), "Podcast")]
public partial class PodcastDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    Podcast podcast;
}
