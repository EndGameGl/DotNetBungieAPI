using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemObjectivesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemObjectivesComponent>();
    }
}