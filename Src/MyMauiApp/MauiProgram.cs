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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            //// Local Notification
            //builder.UseLocalNotification();

            // Add Hardware Services
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            // Add ViewModels
            builder.Services.AddSingleton<ViewModels.ProductDetailViewModel>();
            builder.Services.AddSingleton<ViewModels.ProductsViewModel>();

            // Add Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<DetailPage>();

            // Add Services
            builder.Services.AddSingleton<Services.ProductService>(); 

            return builder.Build();
        }
    }
}
