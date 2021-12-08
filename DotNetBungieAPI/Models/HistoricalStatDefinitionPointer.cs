using System.Diagnostics;
using DotNetBungieAPI.Clients;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.Models;

/// <summary>
///     Class that points to <see cref="HistoricalStatDefinition" /> in repository or provider.
/// </summary>
[DebuggerDisplay("{StatId}")]
public sealed class HistoricalStatDefinitionPointer
{
    private static readonly Lazy<IBungieClient> _client =
        new(() => ServiceProviderInstance.Instance.GetService<IBungieClient>());

    private bool _isMapped;
    private DestinyHistoricalStatsDefinition _value;

    /// <summary>
    ///     Class constructor
    /// </summary>
    /// <param name="statId">Pointer key</param>
    public HistoricalStatDefinitionPointer(string statId)
    {
        _value = default;
        _isMapped = false;
        StatId = statId;
    }

    /// <summary>
    ///     Empty default <see cref="HistoricalStatDefinitionPointer" />
    /// </summary>
    public static HistoricalStatDefinitionPointer Empty { get; } = new(null);

    /// <summary>
    ///     Locale of this definition
    /// </summary>
    public BungieLocales Locale { get; private set; } = BungieLocales.EN;

    /// <summary>
    ///     ID of this stat definition
    /// </summary>
    public string StatId { get; }

    /// <summary>
    ///     Attempts to get definition from this pointer
    /// </summary>
    /// <param name="definition"></param>
    /// <returns></returns>
    public bool TryGetDefinition(out DestinyHistoricalStatsDefinition definition)
    {
        definition = default;

        if (_isMapped)
        {
            definition = _value;
            return true;
        }

        if (_client.Value.TryGetHistoricalStatDefinition(StatId, Locale, out definition))
        {
            _value = definition;
            _isMapped = true;
            return true;
        }

        return true;
    }

    /// <summary>
    ///     Attempts to map value for this pointer
    /// </summary>
    public void TryMapValue()
    {
        if (_value != null && _isMapped)
            return;
        if (string.IsNullOrWhiteSpace(StatId))
            return;

        if (_client.Value.TryGetHistoricalStatDefinition(StatId, Locale, out var definition))
        {
            _value = definition;
            _isMapped = true;
        }
    }

    internal void SetLocale(BungieLocales locale)
    {
        Locale = locale;
    }
}