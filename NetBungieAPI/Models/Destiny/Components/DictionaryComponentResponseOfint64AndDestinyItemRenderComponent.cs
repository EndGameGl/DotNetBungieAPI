using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyItemRenderComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyItemRenderComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyItemRenderComponent>();
    }
}