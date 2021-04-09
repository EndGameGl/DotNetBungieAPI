using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyInventoryComponent
    {
        [JsonPropertyName("items")]
        public ReadOnlyCollection<DestinyItemComponent> Items { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemComponent>();
    }
}
