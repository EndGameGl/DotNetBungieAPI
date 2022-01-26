namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The definition for an "inventory flyout": a UI screen where we show you part of an otherwise hidden vendor inventory: like the Vault inventory buckets.
/// </summary>
public class DestinyVendorInventoryFlyoutDefinition : IDeepEquatable<DestinyVendorInventoryFlyoutDefinition>
{
    /// <summary>
    ///     If the flyout is locked, this is the reason why.
    /// </summary>
    [JsonPropertyName("lockedDescription")]
    public string LockedDescription { get; set; }

    /// <summary>
    ///     The title and other common properties of the flyout.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     A list of inventory buckets and other metadata to show on the screen.
    /// </summary>
    [JsonPropertyName("buckets")]
    public List<Destiny.Definitions.DestinyVendorInventoryFlyoutBucketDefinition> Buckets { get; set; }

    /// <summary>
    ///     An identifier for the flyout, in case anything else needs to refer to them.
    /// </summary>
    [JsonPropertyName("flyoutId")]
    public uint FlyoutId { get; set; }

    /// <summary>
    ///     If this is true, don't show any of the glistening "this is a new item" UI elements, like we show on the inventory items themselves in in-game UI.
    /// </summary>
    [JsonPropertyName("suppressNewness")]
    public bool SuppressNewness { get; set; }

    /// <summary>
    ///     If this flyout is meant to show you the contents of the player's equipment slot, this is the slot to show.
    /// </summary>
    [JsonPropertyName("equipmentSlotHash")]
    public uint? EquipmentSlotHash { get; set; }

    public bool DeepEquals(DestinyVendorInventoryFlyoutDefinition? other)
    {
        return other is not null &&
               LockedDescription == other.LockedDescription &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Buckets.DeepEqualsList(other.Buckets) &&
               FlyoutId == other.FlyoutId &&
               SuppressNewness == other.SuppressNewness &&
               EquipmentSlotHash == other.EquipmentSlotHash;
    }
}