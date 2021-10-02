using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemTalentGridComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemTalentGridComponent>();
    }
}