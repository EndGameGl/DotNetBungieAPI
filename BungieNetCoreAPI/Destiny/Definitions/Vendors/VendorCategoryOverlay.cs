using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Vendors
{
    public class VendorCategoryOverlay : IDeepEquatable<VendorCategoryOverlay>
    {
        public string ChoiceDescription { get; }
        public string Description { get; }
        public string Icon { get; }
        public string Title { get; }
        public DefinitionHashPointer<DestinyInventoryItemDefinition> CurrencyItem { get; }

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
