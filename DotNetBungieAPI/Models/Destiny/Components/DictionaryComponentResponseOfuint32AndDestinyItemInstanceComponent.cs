using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemInstanceComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemInstanceComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemInstanceComponent>();
    }
}