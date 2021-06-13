using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemPerksComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemPerksComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemPerksComponent>();
    }
}