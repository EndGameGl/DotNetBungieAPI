using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCollectibleComponent
    {
        [JsonPropertyName("state")]
        public DestinyCollectibleState State { get; init; }
    }
}
