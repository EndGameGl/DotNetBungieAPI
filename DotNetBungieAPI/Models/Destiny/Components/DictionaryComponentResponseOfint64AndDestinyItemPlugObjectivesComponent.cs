using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemPlugObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemPlugObjectivesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemPlugObjectivesComponent>();
    }
}