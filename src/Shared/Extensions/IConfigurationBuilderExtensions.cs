﻿using System.Reflection;

namespace Microsoft.Extensions.Configuration;

public static partial class IConfigurationBuilderExtensions
{
    /// <summary>
    /// Configuration priority (Lowest to highest) =>
    /// Shared/appsettings.json
    /// Shared/appsettings.Production.json
    ///     Server.Api only =>
    ///         Server/appsettings.json
    ///         Server/appsettings.Production.json
    ///         https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration#default-application-configuration-sources
    /// </summary>
    public static void AddSharedConfigurations(this IConfigurationBuilder builder)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder();

        var sharedAssembly = Assembly.Load("Bit.TemplatePlayground.Shared");

        configBuilder.AddJsonStream(sharedAssembly.GetManifestResourceStream("Bit.TemplatePlayground.Shared.appsettings.json")!);

        var envSharedAppSettings = sharedAssembly.GetManifestResourceStream($"Bit.TemplatePlayground.Shared.appsettings.{AppEnvironment.Current}.json");
        if (envSharedAppSettings != null)
        {
            configBuilder.AddJsonStream(envSharedAppSettings);
        }

        var originalSources = builder.Sources.ToList();
        builder.Sources.Clear();
        builder.Sources.AddRange(configBuilder.Sources.Union(originalSources));
    }
}
