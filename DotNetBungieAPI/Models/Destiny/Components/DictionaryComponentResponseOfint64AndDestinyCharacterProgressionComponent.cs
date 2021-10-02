using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterProgressionComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterProgressionComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCharacterProgressionComponent>();
    }
}