using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemTalentGridComponent> Data { get; init; } =
            ReadOnlyDictionaries<long, DestinyItemTalentGridComponent>.Empty;
    }
}