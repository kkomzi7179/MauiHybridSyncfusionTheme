using CommunityToolkit.Maui;

using MauiApp1.Data;
using MauiApp1.Services;
using MauiApp1.ViewModel;

using Microsoft.Extensions.Logging;

using Syncfusion.Blazor;
using Syncfusion.Maui.Core.Hosting;


namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureEssentials()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services
                .AddSyncfusionBlazor()
                .RegisterAppServices()
                .RegisterViewModels()
                .RegisterViews();
            
            return builder.Build();
        }
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddSingleton<CascadingAppState>();

            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HybridPageViewModel>();

            return services;
        }

        public static IServiceCollection RegisterViews(this IServiceCollection services)
        {
            //services.AddTransient<HybridPage>();

            return services;
        }
    }
}