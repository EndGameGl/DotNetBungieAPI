using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public class DestinyCurrenciesComponent
    {
        [JsonPropertyName("itemQuantities")]
        public ReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, object> ItemQuantities { get; init; } = Defaults.EmptyReadOnlyDictionary<DefinitionHashPointer<DestinyInventoryItemDefinition>, object>();
    }
}
