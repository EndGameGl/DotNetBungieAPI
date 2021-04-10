using NetBungieAPI.Models.Destiny.Items;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemSocketsComponent
    {
        [JsonPropertyName("sockets")]
        public ReadOnlyCollection<DestinyItemSocketState> Sockets { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemSocketState>();
    }
}
