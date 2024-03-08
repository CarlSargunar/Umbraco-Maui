﻿using Microsoft.Extensions.Logging;
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
            builder.Services.AddSingleton<ViewModels.ArticlesViewModel>();
            builder.Services.AddSingleton<ViewModels.PodcastsViewModel>();


            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ArticleListPage>();
            builder.Services.AddSingleton<ArticleDetailPage>();
            builder.Services.AddSingleton<PodcastListPage>();
            builder.Services.AddSingleton<PodcastDetailPage>();

            // Add Services
            builder.Services.AddSingleton<Services.ContentDeliveryService>();


            return builder.Build();
        }
    }
}
