using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyStringVariablesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyStringVariablesComponent>();
    }
}