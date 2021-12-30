using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     BNet's custom categorization of reward sources. We took a look at the existing ways that items could be spawned, and tried to make high-level categorizations of them. This needs to be re-evaluated for Destiny 2.
/// </summary>
public enum DestinyRewardSourceCategory : int
{
    /// <summary>
    ///     The source doesn't fit well into any of the other types.
    /// </summary>
    None = 0,
    /// <summary>
    ///     The source is directly related to the rewards gained by playing an activity or set of activities. This currently includes Quests and other action in-game.
    /// </summary>
    Activity = 1,
    /// <summary>
    ///     This source is directly related to items that Vendors sell.
    /// </summary>
    Vendor = 2,
    /// <summary>
    ///     This source is a custom aggregation of items that can be earned in many ways, but that share some other property in common that is useful to share. For instance, in Destiny 1 we would make "Reward Sources" for every game expansion: that way, you could search reward sources to see what items became available with any given Expansion.
    /// </summary>
    Aggregate = 3
}
