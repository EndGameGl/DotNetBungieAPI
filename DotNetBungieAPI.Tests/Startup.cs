using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .UseBungieApiClient(settings =>
                {
                    settings.ApiKey = "";
                    settings.CacheDefinitions = true;
                    settings.ClientId = 0;
                    settings.ClientSecret = "";
                    settings.ApplicationScopes = ApplicationScopes.ReadUserData |
                                                 ApplicationScopes.ReadBasicUserProfile |
                                                 ApplicationScopes.MoveEquipDestinyItems |
                                                 ApplicationScopes.AdminGroups;
                    settings.UsedLocales.Add(BungieLocales.EN);
                    settings
                        .UseDefaultLogger(loggerConfig =>
                        {
                            loggerConfig.IsEnabled = false;
                            loggerConfig.LogEventLevels(new[]
                                { LogLevel.Debug, LogLevel.Error, LogLevel.Information });
                        })
                        .UseDefaultBungieNetJsonSerializer(c => { })
                        .UseDefaultAuthorizationHandler()
                        .UseDefaultDefinitionProvider(c =>
                        {
                            c.ManifestFolderPath = @"";
                            c.AutoUpdateManifestOnStartup = true;
                            c.DeleteOldManifestDataAfterUpdates = false;
                        })
                        .UseDefaultHttpClient(c => { })
                        .UseDefaultDefinitionRepository(c => { });
                });

            services.BuildServiceProvider().GetRequiredService<IBungieClient>();
        }
    }
}