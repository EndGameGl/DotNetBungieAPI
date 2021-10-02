using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyInventoryComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyInventoryComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyInventoryComponent>();
    }
}