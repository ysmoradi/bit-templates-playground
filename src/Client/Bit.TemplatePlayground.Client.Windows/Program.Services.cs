using System.Net.Http;
using Microsoft.Extensions.Logging;
using Bit.TemplatePlayground.Client.Windows.Services;
using Bit.TemplatePlayground.Client.Windows.Configuration;

namespace Bit.TemplatePlayground.Client.Windows;

public static partial class Program
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        // Services being registered here can get injected in windows project only.

        ConfigurationBuilder configurationBuilder = new();
        configurationBuilder.AddClientConfigurations();
        var configuration = configurationBuilder.Build();
        services.TryAddTransient<IConfiguration>(sp => configuration);

        Uri.TryCreate(configuration.GetServerAddress(), UriKind.Absolute, out var serverAddress);
        services.TryAddSingleton(sp =>
        {
            var handler = sp.GetRequiredKeyedService<DelegatingHandler>("DefaultMessageHandler");
            HttpClient httpClient = new(handler)
            {
                BaseAddress = serverAddress
            };
            return httpClient;
        });

        services.AddWpfBlazorWebView();
        if (AppEnvironment.IsDev())
        {
            services.AddBlazorWebViewDeveloperTools();
        }

        services.TryAddTransient<IStorageService, WindowsStorageService>();
        services.TryAddTransient<IBitDeviceCoordinator, WindowsDeviceCoordinator>();
        services.TryAddTransient<IExceptionHandler, WindowsExceptionHandler>();
        services.AddSingleton<ILocalHttpServer, WindowsLocalHttpServer>();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
            loggingBuilder.AddEventLog();
            loggingBuilder.AddEventSourceLogger();
            if (AppEnvironment.IsDev())
            {
                loggingBuilder.AddDebug();
            }
            loggingBuilder.AddConsole();
        });

        services.AddOptions<WindowsUpdateSettings>()
            .Bind(configuration.GetRequiredSection(nameof(WindowsUpdateSettings)))
            .ValidateOnStart();

        services.AddClientCoreProjectServices();
    }
}
