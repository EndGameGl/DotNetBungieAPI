﻿using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.InventoryItems
{
    /// <summary>
    /// A shortcut for the fact that some items have a "Preview Vendor" - See DestinyInventoryItemDefinition.preview.previewVendorHash - that is intended to be used to show what items you can get as a result of acquiring or using this item.
    /// <para/>
    /// A common example of this in Destiny 1 was Eververse "Boxes," which could have many possible items. This "Preview Vendor" is not a vendor you can actually see in the game, but it defines categories and sale items for all of the possible items you could get from the Box so that the game can show them to you. We summarize that info here so that you don't have to do that Vendor lookup and aggregation manually.
    /// </summary>
    public sealed record DestinyDerivedItemCategoryDefinition : IDeepEquatable<DestinyDerivedItemCategoryDefinition>
    {
        [JsonPropertyName("categoryDescription")]
        public string CategoryDescription { get; init; }
        [JsonPropertyName("items")]
        public ReadOnlyCollection<DestinyDerivedItemDefinition> Items { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyDerivedItemDefinition>();

        public bool DeepEquals(DestinyDerivedItemCategoryDefinition other)
        {
            return other != null &&
                CategoryDescription == other.CategoryDescription &&
                Items.DeepEqualsReadOnlyCollections(other.Items);
        }
    }
}