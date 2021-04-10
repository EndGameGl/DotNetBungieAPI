using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Items
{
    public sealed record DestinyItemSocketState
    {
        [JsonPropertyName("plugHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Plug { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("isEnabled")]
        public bool IsEnabled { get; init; }
        [JsonPropertyName("isVisible")]
        public bool IsVisible { get; init; }
        [JsonPropertyName("enableFailIndexes")]
        public ReadOnlyCollection<int> EnableFailIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();
    }
}
