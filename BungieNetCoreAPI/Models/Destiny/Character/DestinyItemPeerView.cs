using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Character
{
    public sealed record DestinyItemPeerView
    {
        [JsonPropertyName("itemHash")]
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; init; } = DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;
        [JsonPropertyName("dyes")]
        public ReadOnlyCollection<DyeReference> Dyes { get; init; } = Defaults.EmptyReadOnlyCollection<DyeReference>();
    }
}
