using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemPerksComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemPerksComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemPerksComponent>();
    }
}