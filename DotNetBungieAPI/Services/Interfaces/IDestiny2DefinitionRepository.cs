using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace DotNetBungieAPI.Services.Interfaces;

public interface IDestiny2DefinitionRepository
{
    IEnumerable<BungieLocales> AvailableLocales { get; }
    IEnumerable<DefinitionsEnum> AllowedDefinitions { get; }

    bool TryGetDestinyDefinition<T>(
        uint key,
        BungieLocales locale,
        out T definition) where T : IDestinyDefinition;

    bool TryGetDestinyHistoricalDefinition(
        BungieLocales locale,
        string key,
        out DestinyHistoricalStatsDefinition statsDefinition);

    IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStatsDefinitions(
        BungieLocales locale);

    bool AddDestinyHistoricalDefinition(
        BungieLocales locale,
        DestinyHistoricalStatsDefinition statsDefinition);

    IEnumerable<T> Search<T>(
        DefinitionsEnum definitionType,
        BungieLocales locale,
        Func<IDestinyDefinition, bool> predicate) where T : IDestinyDefinition;

    public IEnumerable<T> GetAll<T>(
        BungieLocales locale = BungieLocales.EN) where T : IDestinyDefinition;

    bool AddDefinition<T>(
        BungieLocales locale,
        T definition) where T : IDestinyDefinition;

    bool AddDefinition(
        DefinitionsEnum enumValue,
        BungieLocales locale,
        IDestinyDefinition definition);

    void Clear();

    void PremapPointers();
}