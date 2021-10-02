using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemStatsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemStatsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemStatsComponent>();
    }
}