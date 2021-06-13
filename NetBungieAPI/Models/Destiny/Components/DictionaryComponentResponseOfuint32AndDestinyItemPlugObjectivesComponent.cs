using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPlugObjectivesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPlugObjectivesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemPlugObjectivesComponent>();
    }
}