using DotNetBungieAPI.Models.Destiny.Quests;

namespace DotNetBungieAPI.Models.Destiny.Kiosks;

public sealed record DestinyKioskItem
{
    /// <summary>
    ///     The index of the item in the related DestinyVendorDefintion's itemList property, representing the sale.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If true, the user can not only see the item, but they can acquire it. It is possible that a user can see a kiosk
    ///     item and not be able to acquire it.
    /// </summary>
    [JsonPropertyName("canAcquire")]
    public bool CanAcquire { get; init; }

    /// <summary>
    ///     Indexes into failureStrings for the Vendor, indicating the reasons why it failed if any.
    /// </summary>
    [JsonPropertyName("failureIndexes")]
    public ReadOnlyCollection<int> FailureIndexes { get; init; }

    /// <summary>
    ///     I may regret naming it this way - but this represents when an item has an objective that doesn't serve a beneficial
    ///     purpose, but rather is used for "flavor" or additional information. For instance, when Emblems track specific
    ///     stats, those stats are represented as Objectives on the item.
    /// </summary>
    [JsonPropertyName("flavorObjective")]
    public DestinyObjectiveProgress FlavorObjective { get; init; }
}