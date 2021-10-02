using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemPlugObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemPlugObjectivesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemPlugObjectivesComponent>();
    }
}