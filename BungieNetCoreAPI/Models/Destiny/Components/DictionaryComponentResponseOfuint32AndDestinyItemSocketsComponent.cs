using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemSocketsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemSocketsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemSocketsComponent>();
    }
}