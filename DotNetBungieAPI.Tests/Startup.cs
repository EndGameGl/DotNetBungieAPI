using DotNetBungieAPI.DefinitionProvider.Sqlite;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Applications;
using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .UseBungieApiClient(builder =>
                {
                    builder.ClientConfiguration.ApiKey = "";
                    builder.ClientConfiguration.CacheDefinitions = true;
                    builder.ClientConfiguration.ClientId = 0;
                    builder.ClientConfiguration.ClientSecret = "";

                    builder.ClientConfiguration.ApplicationScopes = ApplicationScopes.ReadUserData |
                                                                    ApplicationScopes.ReadBasicUserProfile |
                                                                    ApplicationScopes.MoveEquipDestinyItems |
                                                                    ApplicationScopes.AdminGroups;
                    builder.ClientConfiguration.UsedLocales.Add(BungieLocales.EN);
                    builder.DefinitionProvider.UseSqliteDefinitionProvider(options =>
                    {
                        options.ManifestFolderPath =
                            @"F:\ProgrammingStuff\Projects\BungieNetCoreAPIRepository\Manifests";
                        options.AutoUpdateManifestOnStartup = true;
                        options.DeleteOldManifestDataAfterUpdates = false;
                    });
                });

            services.BuildServiceProvider().GetRequiredService<IBungieClient>();
        }
    }
}