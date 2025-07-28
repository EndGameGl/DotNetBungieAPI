namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Data about an item's "sources": ways that the item can be obtained.
/// </summary>
public class DestinyItemSourceBlockDefinition
{
    /// <summary>
    ///     The list of hash identifiers for Reward Sources that hint where the item can be found (DestinyRewardSourceDefinition).
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.DestinyRewardSourceDefinition>("Destiny.Definitions.DestinyRewardSourceDefinition")]
    [JsonPropertyName("sourceHashes")]
    public uint[]? SourceHashes { get; set; }

    /// <summary>
    ///     A collection of details about the stats that were computed for the ways we found that the item could be spawned.
    /// </summary>
    [JsonPropertyName("sources")]
    public Destiny.Definitions.Sources.DestinyItemSourceDefinition[]? Sources { get; set; }

    /// <summary>
    ///     If we found that this item is exclusive to a specific platform, this will be set to the BungieMembershipType enumeration that matches that platform.
    /// </summary>
    [JsonPropertyName("exclusive")]
    public BungieMembershipType Exclusive { get; set; }

    /// <summary>
    ///     A denormalized reference back to vendors that potentially sell this item.
    /// </summary>
    [JsonPropertyName("vendorSources")]
    public Destiny.Definitions.DestinyItemVendorSourceReference[]? VendorSources { get; set; }
}
