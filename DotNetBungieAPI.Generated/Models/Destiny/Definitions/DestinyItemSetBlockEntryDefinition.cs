namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Defines a particular entry in an ItemSet (AKA a particular Quest Step in a Quest)
/// </summary>
public class DestinyItemSetBlockEntryDefinition
{
    /// <summary>
    ///     Used for tracking which step a user reached. These values will be populated in the user's internal state, which we expose externally as a more usable DestinyQuestStatus object. If this item has been obtained, this value will be set in trackingUnlockValueHash.
    /// </summary>
    [JsonPropertyName("trackingValue")]
    public int? TrackingValue { get; set; }

    /// <summary>
    ///     This is the hash identifier for a DestinyInventoryItemDefinition representing this quest step.
    /// </summary>
    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }
}
