using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint32AndDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<int, DestinyItemReusablePlugsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<int, DestinyItemReusablePlugsComponent>();
    }
}