using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemTalentGridComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemTalentGridComponent>();
    }
}