using System.Diagnostics.CodeAnalysis;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Destiny.HistoricalStats.Definitions;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Access to Destiny 2 Definitions storage
/// </summary>
public interface IDestiny2DefinitionRepository
{
    /// <summary>
    ///     Available locales for current Destiny 2 Definitions repository
    /// </summary>
    IEnumerable<BungieLocales> AvailableLocales { get; }

    /// <summary>
    ///     All definition types available in this repository
    /// </summary>
    IEnumerable<DefinitionsEnum> AllowedDefinitions { get; }

    /// <summary>
    ///     Attempts to get definition of certain type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hash">Definition hash</param>
    /// <param name="locale">Definition locale</param>
    /// <param name="definition">Found definition</param>
    /// <returns>True, if definition exists, False, if no definition is present</returns>
    bool TryGetDestinyDefinition<T>(uint hash, [NotNullWhen(true)] out T? definition, BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Gets DestinyHistoricalStatsDefinition with provided Id
    /// </summary>
    /// <param name="id">Definition Id</param>
    /// <param name="locale">Definition locale</param>
    /// <param name="statsDefinition">Found definition</param>
    /// <returns>True, if definition exists, False, if no definition is present</returns>
    bool TryGetDestinyHistoricalDefinition(string id, [NotNullWhen(true)] out DestinyHistoricalStatsDefinition? statsDefinition, BungieLocales locale = BungieLocales.EN);

    /// <summary>
    ///     Enumerates all DestinyHistoricalStatsDefinition of provided locale
    /// </summary>
    /// <param name="locale">Definitions locale</param>
    /// <returns></returns>
    IEnumerable<DestinyHistoricalStatsDefinition> GetAllHistoricalStatsDefinitions(BungieLocales locale = BungieLocales.EN);

    /// <summary>
    ///     Adds DestinyHistoricalStatsDefinition to repository
    /// </summary>
    /// <param name="statsDefinition">Definition</param>
    /// <param name="locale">Definition locale</param>
    /// <returns></returns>
    bool AddDestinyHistoricalDefinition(DestinyHistoricalStatsDefinition statsDefinition, BungieLocales locale = BungieLocales.EN);

    /// <summary>
    ///     Searches to definitions that match the condition
    /// </summary>
    /// <typeparam name="T">Definition type</typeparam>
    /// <param name="predicate">Condition</param>
    /// <param name="locale">Definitions locale</param>
    /// <returns></returns>
    IEnumerable<T> Search<T>(Func<T, bool> predicate, BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Enumerates all definitions of certain type
    /// </summary>
    /// <typeparam name="T">Definition type</typeparam>
    /// <param name="locale">Definitions locale</param>
    /// <returns></returns>
    public IEnumerable<T> GetAll<T>(BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Adds new definition to repository
    /// </summary>
    /// <typeparam name="T">Definition type</typeparam>
    /// <param name="definition">Definition</param>
    /// <param name="locale">Definition locale</param>
    /// <returns>Whether definition was added to repository</returns>
    bool AddDefinition<T>(T definition, BungieLocales locale = BungieLocales.EN)
        where T : class, IDestinyDefinition;

    /// <summary>
    ///     Adds definition to storage
    /// </summary>
    /// <param name="definition">Definition</param>
    /// <param name="locale">Definition locale</param>
    /// <returns>Whether definition was added to repository</returns>
    bool AddDefinition(IDestinyDefinition definition, BungieLocales locale = BungieLocales.EN);

    /// <summary>
    ///     Clears repository of all definitions
    /// </summary>
    void Clear();

    /// <summary>
    ///     Clears repository of certain definition type
    /// </summary>
    /// <param name="definitionType">Definition type</param>
    /// <param name="clearHistoricalDefinitions"></param>
    void Clear(DefinitionsEnum definitionType, bool? clearHistoricalDefinitions = null);

    /// <summary>
    ///     Clears repository of certain locale definition type
    /// </summary>
    /// <param name="definitionType"></param>
    /// <param name="locale"></param>
    /// <param name="clearHistoricalDefinitions"></param>
    void Clear(DefinitionsEnum definitionType, BungieLocales locale, bool? clearHistoricalDefinitions = null);

    /// <summary>
    ///     Clears repository of certain locale
    /// </summary>
    /// <param name="locale"></param>
    void Clear(BungieLocales locale);
}
