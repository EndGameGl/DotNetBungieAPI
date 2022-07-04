namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     This defines an item's "Value". Unfortunately, this appears to be used in different ways depending on the way that
///     the item itself is used.
///     <para />
///     For items being sold at a Vendor, this is the default "sale price" of the item.These days, the vendor itself almost
///     always sets the price, but it still possible for the price to fall back to this value.For quests, it is a preview
///     of rewards you can gain by completing the quest.For dummy items, if the itemValue refers to an Emblem, it is the
///     emblem that should be shown as the reward. (jeez louise)
///     <para />
///     It will likely be used in a number of other ways in the future, it appears to be a bucket where they put arbitrary
///     items and quantities into the item.
/// </summary>
public sealed record DestinyItemValueBlockDefinition : IDeepEquatable<DestinyItemValueBlockDefinition>
{
    /// <summary>
    ///     References to the items that make up this item's "value", and the quantity.
    /// </summary>
    [JsonPropertyName("itemValue")]
    public ReadOnlyCollection<DestinyItemQuantity> ItemValue { get; init; } =
        ReadOnlyCollections<DestinyItemQuantity>.Empty;

    /// <summary>
    ///     If there's a localized text description of the value provided, this will be said description.
    /// </summary>
    [JsonPropertyName("valueDescription")]
    public string ValueDescription { get; init; }

    public bool DeepEquals(DestinyItemValueBlockDefinition other)
    {
        return other != null &&
               ItemValue.DeepEqualsReadOnlyCollections(other.ItemValue) &&
               ValueDescription == other.ValueDescription;
    }
}