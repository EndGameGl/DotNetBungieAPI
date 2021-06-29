using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterRecordsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterRecordsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCharacterRecordsComponent>();
    }
}