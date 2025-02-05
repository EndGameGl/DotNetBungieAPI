﻿namespace DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

/// <summary>
///     A shortcut for the fact that some items have a "Preview Vendor" - See
///     DestinyInventoryItemDefinition.preview.previewVendorHash - that is intended to be used to show what items you can
///     get as a result of acquiring or using this item.
///     <para />
///     A common example of this in Destiny 1 was Eververse "Boxes," which could have many possible items. This "Preview
///     Vendor" is not a vendor you can actually see in the game, but it defines categories and sale items for all of the
///     possible items you could get from the Box so that the game can show them to you. We summarize that info here so
///     that you don't have to do that Vendor lookup and aggregation manually.
/// </summary>
public sealed record DestinyDerivedItemCategoryDefinition
    : IDeepEquatable<DestinyDerivedItemCategoryDefinition>
{
    /// <summary>
    ///     The localized string for the category title. This will be something describing the items you can get as a group, or
    ///     your likelihood/the quantity you'll get.
    /// </summary>
    [JsonPropertyName("categoryDescription")]
    public string CategoryDescription { get; init; }

    /// <summary>
    ///     This is the list of all of the items for this category and the basic properties we'll know about them.
    /// </summary>
    [JsonPropertyName("items")]
    public ReadOnlyCollection<DestinyDerivedItemDefinition> Items { get; init; } =
        ReadOnlyCollection<DestinyDerivedItemDefinition>.Empty;

    public bool DeepEquals(DestinyDerivedItemCategoryDefinition other)
    {
        return other != null
            && CategoryDescription == other.CategoryDescription
            && Items.DeepEqualsReadOnlyCollection(other.Items);
    }
}
