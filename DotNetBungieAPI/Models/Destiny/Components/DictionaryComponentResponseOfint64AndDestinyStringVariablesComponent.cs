using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyStringVariablesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyStringVariablesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyStringVariablesComponent>();
    }
}