using Microsoft.Extensions.Logging;
using MyApp.Views;

namespace MyApp
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
            builder.Services.AddSingleton<ViewModels.ArticleDetailsViewModel>();
            builder.Services.AddSingleton<ViewModels.PodcastDetailsViewModel>();

            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ArticleList>();
            builder.Services.AddSingleton<ArticleDetail>();
            builder.Services.AddSingleton<PodcastList>();
            builder.Services.AddSingleton<PodcastDetail>();

            // Add Services
            builder.Services.AddSingleton<Services.ContentDeliveryService>();


            return builder.Build();
        }
    }
}
