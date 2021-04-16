using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace NetBungieAPI.Models.Destiny.HistoricalStats
{
    public class DestinyHistoricalWeaponStats
    {
        [JsonPropertyName("referenceId")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> ItemReference { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

        [JsonPropertyName("values")]
        public ReadOnlyDictionary<string, DestinyHistoricalStatsValue> Values { get; init; } =
            Defaults.EmptyReadOnlyDictionary<string, DestinyHistoricalStatsValue>();
    }
}
