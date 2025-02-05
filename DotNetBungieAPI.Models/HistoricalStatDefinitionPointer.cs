using System.Diagnostics;
using DotNetBungieAPI.Models.Destiny.Definitions.HistoricalStats;

namespace DotNetBungieAPI.Models;

/// <summary>
///     Class that points to <see cref="DestinyHistoricalStatsDefinition" /> in repository or provider.
/// </summary>
[DebuggerDisplay("{StatId}")]
public readonly struct HistoricalStatDefinitionPointer
{
    /// <summary>
    ///     Class constructor
    /// </summary>
    /// <param name="statId">Pointer key</param>
    public HistoricalStatDefinitionPointer(string? statId)
    {
        StatId = statId;
    }

    /// <summary>
    ///     Empty default <see cref="HistoricalStatDefinitionPointer" />
    /// </summary>
    public static HistoricalStatDefinitionPointer Empty { get; } = new(null!);

    /// <summary>
    ///     ID of this stat definition
    /// </summary>
    public string? StatId { get; }

    /// <summary>
    ///     Checks whether stat id is present
    /// </summary>
    public bool HasValue => !string.IsNullOrEmpty(StatId);
}
