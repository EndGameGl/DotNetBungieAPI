using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Vendors
{
    public sealed record DestinyVendorCategoryOverlayDefinition : IDeepEquatable<DestinyVendorCategoryOverlayDefinition>
    {
        [JsonPropertyName("choiceDescription")]
        public string ChoiceDescription { get; init; }
        [JsonPropertyName("description")]
        public string Description { get; init; }
        [JsonPropertyName("icon")]
        public string Icon { get; init; }
        [JsonPropertyName("title")]
        public string Title { get; init; }
        [JsonPropertyName("currencyItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        public bool DeepEquals(DestinyVendorCategoryOverlayDefinition other)
        {
            return other != null &&
                   ChoiceDescription == other.ChoiceDescription &&
                   Description == other.Description &&
                   Icon == other.Icon &&
                   Title == other.Title &&
                   CurrencyItem.DeepEquals(other.CurrencyItem);
        }
    }
}
