using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyItemRenderComponent
    {
        [JsonPropertyName("useCustomDyes")]
        public bool UseCustomDyes { get; init; }
        [JsonPropertyName("artRegions")]
        public ReadOnlyDictionary<int, int> ArtRegions { get; init; } = Defaults.EmptyReadOnlyDictionary<int, int>();
    }
}
