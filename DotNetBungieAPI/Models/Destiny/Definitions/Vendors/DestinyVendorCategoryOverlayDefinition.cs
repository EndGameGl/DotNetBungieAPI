using System.Text.Json.Serialization;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Vendors
{
    /// <summary>
    ///     The details of an overlay prompt to show to a user. They are all fairly self-explanatory localized strings that can
    ///     be shown.
    /// </summary>
    public sealed record DestinyVendorCategoryOverlayDefinition : IDeepEquatable<DestinyVendorCategoryOverlayDefinition>
    {
        [JsonPropertyName("choiceDescription")]
        public string ChoiceDescription { get; init; }

        [JsonPropertyName("description")] public string Description { get; init; }
        [JsonPropertyName("icon")] public DestinyResource Icon { get; init; }
        [JsonPropertyName("title")] public string Title { get; init; }

        /// <summary>
        ///     If this overlay has a currency item that it features, this is said featured item.
        /// </summary>
        [JsonPropertyName("currencyItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; init; } =
            DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

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