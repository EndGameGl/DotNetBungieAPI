using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Items
{
    public sealed record PlugItemSettings
    {
        [JsonPropertyName("plugItemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> PlugItem { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("canInsert")]
        public bool CanInsert { get; init; }
        [JsonPropertyName("enabled")]
        public bool IsEnabled { get; init; }
    }
}
