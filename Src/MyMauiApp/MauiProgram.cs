using Microsoft.Extensions.Logging;
using MyMauiApp.Views;
using Plugin.Maui.Audio;

namespace MyMauiApp
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
		builder.Logging.AddDebug();
#endif

			// Add Hardware Services
			builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

			// Add ViewModels
			builder.Services.AddSingleton<ViewModels.PodcastDetailViewModel>();
			builder.Services.AddSingleton<ViewModels.PodcastsViewModel>();

			// Add Pages
			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<DetailPage>();

			// Add Services
			builder.Services.AddSingleton<Services.ContentService>();
			builder.Services.AddSingleton(AudioManager.Current);

			return builder.Build();
		}
	}
}