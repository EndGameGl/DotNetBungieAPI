namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Sources;

/// <summary>
///     Properties of a DestinyInventoryItemDefinition that store all of the information we were able to discern about how the item spawns, and where you can find the item.
/// <para />
///     Items will have many of these sources, one per level at which it spawns, to try and give more granular data about where items spawn for specific level ranges.
/// </summary>
public class DestinyItemSourceDefinition
{
    /// <summary>
    ///     The level at which the item spawns. Essentially the Primary Key for this source data: there will be multiple of these source entries per item that has source data, grouped by the level at which the item spawns.
    /// </summary>
    [JsonPropertyName("level")]
    public int? Level { get; set; }

    /// <summary>
    ///     The minimum Quality at which the item spawns for this level. Examine DestinyInventoryItemDefinition for more information about what Quality means. Just don't ask Phaedrus about it, he'll never stop talking and you'll have to write a book about it.
    /// </summary>
    [JsonPropertyName("minQuality")]
    public int? MinQuality { get; set; }

    /// <summary>
    ///     The maximum quality at which the item spawns for this level.
    /// </summary>
    [JsonPropertyName("maxQuality")]
    public int? MaxQuality { get; set; }

    /// <summary>
    ///     The minimum Character Level required for equipping the item when the item spawns at the item level defined on this DestinyItemSourceDefinition, as far as we saw in our processing.
    /// </summary>
    [JsonPropertyName("minLevelRequired")]
    public int? MinLevelRequired { get; set; }

    /// <summary>
    ///     The maximum Character Level required for equipping the item when the item spawns at the item level defined on this DestinyItemSourceDefinition, as far as we saw in our processing.
    /// </summary>
    [JsonPropertyName("maxLevelRequired")]
    public int? MaxLevelRequired { get; set; }

    /// <summary>
    ///     The stats computed for this level/quality range.
    /// </summary>
    [JsonPropertyName("computedStats")]
    public Dictionary<uint, Destiny.Definitions.DestinyInventoryItemStatDefinition> ComputedStats { get; set; }

    /// <summary>
    ///     The DestinyRewardSourceDefinitions found that can spawn the item at this level.
    /// </summary>
    [Destiny2DefinitionList<Destiny.Definitions.DestinyRewardSourceDefinition>("Destiny.Definitions.DestinyRewardSourceDefinition")]
    [JsonPropertyName("sourceHashes")]
    public List<uint> SourceHashes { get; set; }
}
