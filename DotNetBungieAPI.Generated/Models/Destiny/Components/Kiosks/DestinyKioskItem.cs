namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Kiosks;

public class DestinyKioskItem
{
    /// <summary>
    ///     The index of the item in the related DestinyVendorDefintion's itemList property, representing the sale.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If true, the user can not only see the item, but they can acquire it. It is possible that a user can see a kiosk item and not be able to acquire it.
    /// </summary>
    [JsonPropertyName("canAcquire")]
    public bool CanAcquire { get; set; }

    /// <summary>
    ///     Indexes into failureStrings for the Vendor, indicating the reasons why it failed if any.
    /// </summary>
    [JsonPropertyName("failureIndexes")]
    public List<int> FailureIndexes { get; set; }

    /// <summary>
    ///     I may regret naming it this way - but this represents when an item has an objective that doesn't serve a beneficial purpose, but rather is used for "flavor" or additional information. For instance, when Emblems track specific stats, those stats are represented as Objectives on the item.
    /// </summary>
    [JsonPropertyName("flavorObjective")]
    public object FlavorObjective { get; set; }
}
