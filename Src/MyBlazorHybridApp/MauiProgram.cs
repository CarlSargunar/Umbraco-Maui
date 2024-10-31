using Microsoft.Extensions.Logging;
using MyBlazorHybridApp.Services;

namespace MyBlazorHybridApp
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            // Add Services
            builder.Services.AddSingleton<MyMauiApp.Services.ProductService>();
            builder.Services.AddScoped<StateService>();



            return builder.Build();
        }
    }
}
