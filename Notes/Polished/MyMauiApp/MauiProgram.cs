﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MyMauiApp.Views;

namespace MyMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
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
            builder.Services.AddSingleton<ViewModels.ProductsViewModel>();
            builder.Services.AddSingleton<ViewModels.ProductDetailViewModel>();

            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPage>();

            // Add Services
            builder.Services.AddSingleton<Services.ProductService>();

            return builder.Build();
        }
    }
}