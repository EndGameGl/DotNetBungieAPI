namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Represents a stat on an item *or* Character (NOT a Historical Stat, but a physical attribute stat like Attack, Defense etc...)
/// </summary>
public sealed class DestinyStat
{
    /// <summary>
    ///     The hash identifier for the Stat. Use it to look up the DestinyStatDefinition for static data about the stat.
    /// </summary>
    [JsonPropertyName("statHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyStatDefinition> StatHash { get; init; }

    /// <summary>
    ///     The current value of the Stat.
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; init; }
}
