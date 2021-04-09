using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterComponent> Data { get; init; } = Defaults.EmptyReadOnlyDictionary<long, DestinyCharacterComponent>();
    }
}
