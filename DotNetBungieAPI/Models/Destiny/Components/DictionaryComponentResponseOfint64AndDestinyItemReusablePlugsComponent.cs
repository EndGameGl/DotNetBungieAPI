using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemReusablePlugsComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemReusablePlugsComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemReusablePlugsComponent>();
    }
}