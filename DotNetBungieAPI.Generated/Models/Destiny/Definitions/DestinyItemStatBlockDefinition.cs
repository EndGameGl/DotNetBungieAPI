namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Information about the item's calculated stats, with as much data as we can find for the stats without having an actual instance of the item.
/// <para />
///     Note that this means the entire concept of providing these stats is fundamentally insufficient: we cannot predict with 100% accuracy the conditions under which an item can spawn, so we use various heuristics to attempt to simulate the conditions as accurately as possible. Actual stats for items in-game can and will vary, but these should at least be useful base points for comparison and display.
/// <para />
///     It is also worth noting that some stats, like Magazine size, have further calculations performed on them by scripts in-game and on the game servers that BNet does not have access to. We cannot know how those stats are further transformed, and thus some stats will be inaccurate even on instances of items in BNet vs. how they appear in-game. This is a known limitation of our item statistics, without any planned fix.
/// </summary>
public class DestinyItemStatBlockDefinition
{
    /// <summary>
    ///     If true, the game won't show the "primary" stat on this item when you inspect it.
    /// <para />
    ///     NOTE: This is being manually mapped, because I happen to want it in a block that isn't going to directly create this derivative block.
    /// </summary>
    [JsonPropertyName("disablePrimaryStatDisplay")]
    public bool DisablePrimaryStatDisplay { get; set; }

    /// <summary>
    ///     If the item's stats are meant to be modified by a DestinyStatGroupDefinition, this will be the identifier for that definition.
    /// <para />
    ///     If you are using live data or precomputed stats data on the DestinyInventoryItemDefinition.stats.stats property, you don't have to worry about statGroupHash and how it alters stats: the already altered stats are provided to you. But if you want to see how the sausage gets made, or perform computations yourself, this is valuable information.
    /// </summary>
    [JsonPropertyName("statGroupHash")]
    public uint StatGroupHash { get; set; }

    /// <summary>
    ///     If you are looking for precomputed values for the stats on a weapon, this is where they are stored. Technically these are the "Display" stat values. Please see DestinyStatsDefinition for what Display Stat Values means, it's a very long story... but essentially these are the closest values BNet can get to the item stats that you see in-game.
    /// <para />
    ///     These stats are keyed by the DestinyStatDefinition's hash identifier for the stat that's found on the item.
    /// </summary>
    [JsonPropertyName("stats")]
    public Dictionary<uint, Destiny.Definitions.DestinyInventoryItemStatDefinition> Stats { get; set; }

    /// <summary>
    ///     A quick and lazy way to determine whether any stat other than the "primary" stat is actually visible on the item. Items often have stats that we return in case people find them useful, but they're not part of the "Stat Group" and thus we wouldn't display them in our UI. If this is False, then we're not going to display any of these stats other than the primary one.
    /// </summary>
    [JsonPropertyName("hasDisplayableStats")]
    public bool HasDisplayableStats { get; set; }

    /// <summary>
    ///     This stat is determined to be the "primary" stat, and can be looked up in the stats or any other stat collection related to the item.
    /// <para />
    ///     Use this hash to look up the stat's value using DestinyInventoryItemDefinition.stats.stats, and the renderable data for the primary stat in the related DestinyStatDefinition.
    /// </summary>
    [JsonPropertyName("primaryBaseStatHash")]
    public uint PrimaryBaseStatHash { get; set; }
}
