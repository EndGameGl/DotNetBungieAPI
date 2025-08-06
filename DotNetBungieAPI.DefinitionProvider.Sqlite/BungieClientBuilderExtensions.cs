using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.DefinitionProvider.Sqlite;

public static class BungieClientBuilderExtensions
{
    public static void UseSqliteDefinitionProvider(this IServiceConfigurator<IDefinitionProvider> repositoryConfig, Action<SqliteDefinitionProviderConfiguration> configure)
    {
        repositoryConfig.Use<SqliteDefinitionProvider, SqliteDefinitionProviderConfiguration>(configure);
    }
}
