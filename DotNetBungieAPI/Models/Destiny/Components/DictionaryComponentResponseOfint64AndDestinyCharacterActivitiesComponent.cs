using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterActivitiesComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterActivitiesComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCharacterActivitiesComponent>();
    }
}