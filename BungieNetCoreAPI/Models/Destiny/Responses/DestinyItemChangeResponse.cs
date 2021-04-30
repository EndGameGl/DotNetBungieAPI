using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyItemChangeResponse
    {
        [JsonPropertyName("item")]
        public DestinyItemResponse Item { get; init; }
        
        [JsonPropertyName("addedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> AddedInventoryItems { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
        
        [JsonPropertyName("removedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> RemovedInventoryItems { get; init; }=
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
    }
}