using System.Diagnostics;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.Models;

/// <summary>
///     Class that points to <see cref="DestinyHistoricalStatsDefinition" /> in repository or provider.
/// </summary>
[DebuggerDisplay("{StatId}")]
public readonly struct HistoricalStatDefinitionPointer
{
    private static readonly Lazy<IBungieClient> Client =
        new(() => ServiceProviderInstance.Instance.GetService<IBungieClient>());

    /// <summary>
    ///     Class constructor
    /// </summary>
    /// <param name="statId">Pointer key</param>
    public HistoricalStatDefinitionPointer(string statId)
    {
        StatId = statId;
    }

    /// <summary>
    ///     Empty default <see cref="HistoricalStatDefinitionPointer" />
    /// </summary>
    public static HistoricalStatDefinitionPointer Empty { get; } = new(null);

    /// <summary>
    ///     ID of this stat definition
    /// </summary>
    public string StatId { get; }

    /// <summary>
    ///     Checks whether stat id is present
    /// </summary>
    public bool HasValue => !string.IsNullOrEmpty(StatId);

    /// <summary>
    ///     Attempts to get definition from this pointer
    /// </summary>
    /// <param name="definition"></param>
    /// <param name="locale"></param>
    /// <returns></returns>
    public bool TryGetDefinition(
        out DestinyHistoricalStatsDefinition definition, 
        BungieLocales locale = BungieLocales.EN)
    {
        definition = default;
        return Client.Value.TryGetHistoricalStatDefinition(StatId, locale, out definition);
    }
}