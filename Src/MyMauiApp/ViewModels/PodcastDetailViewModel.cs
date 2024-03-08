using Android.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using MyMauiApp.Models;
using MyMauiApp.ViewModels;
using Plugin.Maui.Audio;

namespace MyMauiApp.ViewModels;

[QueryProperty(nameof(Podcast), "Podcast")]
public partial class PodcastDetailViewModel : BaseViewModel
{
    readonly IAudioManager _audioManager;
    public PodcastDetailViewModel(IAudioManager audioManager)
	{
		audioManager = audioManager;
	}

    public async void PlayAudio()
    {
        var audioPlayer = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("ukelele.mp3"));

        audioPlayer.Play();
    }

    [ObservableProperty]
	Podcast podcast;
}