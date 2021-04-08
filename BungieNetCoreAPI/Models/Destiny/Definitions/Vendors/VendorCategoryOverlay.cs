using NetBungieAPI.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Vendors
{
    public class VendorCategoryOverlay : IDeepEquatable<VendorCategoryOverlay>
    {
        public string ChoiceDescription { get; init; }
        public string Description { get; init; }
        public string Icon { get; init; }
        public string Title { get; init; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; init; }

        [JsonConstructor]
        internal VendorCategoryOverlay(string choiceDescription, string description, string icon, string title, uint? currencyItemHash)
        {
            ChoiceDescription = choiceDescription;
            Description = description;
            Icon = icon;
            Title = title;
            CurrencyItem = new DefinitionHashPointer<DestinyInventoryItemDefinition>(currencyItemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(VendorCategoryOverlay other)
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
