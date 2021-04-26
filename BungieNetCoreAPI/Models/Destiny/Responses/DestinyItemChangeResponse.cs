using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Destiny.Components;

namespace NetBungieAPI.Models.Destiny.Responses
{
    public sealed record DestinyItemChangeResponse
    {
        [JsonPropertyName("item")]
        public DestinyItemResponse Item { get; }
        
        [JsonPropertyName("addedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> AddedInventoryItems { get; } =
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
        
        [JsonPropertyName("removedInventoryItems")]
        public ReadOnlyCollection<DestinyItemComponent> RemovedInventoryItems { get; }=
            Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
    }
}