using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DictionaryComponentResponseOfint64AndDestinyCharacterRenderComponent : ComponentResponse
    {
        [JsonPropertyName("data")]
        public ReadOnlyDictionary<long, DestinyCharacterRenderComponent> Data { get; init; } =
            Defaults.EmptyReadOnlyDictionary<long, DestinyCharacterRenderComponent>();
    }
}