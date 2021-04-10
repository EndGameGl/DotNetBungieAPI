using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemStatsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemStatsComponent> Data { get; init; } = Defaults.EmptyReadOnlyDictionary<long, DestinyItemStatsComponent>();
    }
}
