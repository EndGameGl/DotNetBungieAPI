using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfuint32AndDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<uint, DestinyItemReusablePlugsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<uint, DestinyItemReusablePlugsComponent>();
    }
}