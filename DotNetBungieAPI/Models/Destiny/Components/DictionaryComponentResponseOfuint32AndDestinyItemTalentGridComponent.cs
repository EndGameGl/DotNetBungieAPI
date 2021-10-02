using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemTalentGridComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemTalentGridComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemTalentGridComponent>();
    }
}