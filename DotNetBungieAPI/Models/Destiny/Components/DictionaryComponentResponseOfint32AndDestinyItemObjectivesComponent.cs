using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemObjectivesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemObjectivesComponent>();
    }
}