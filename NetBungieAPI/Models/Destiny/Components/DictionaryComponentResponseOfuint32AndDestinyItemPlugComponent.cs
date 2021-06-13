using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPlugComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPlugComponent> Data { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyItemPlugComponent>();
    }
}
