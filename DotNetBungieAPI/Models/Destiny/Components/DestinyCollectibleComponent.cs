using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCollectibleComponent
    {
        [JsonPropertyName("state")] public DestinyCollectibleState State { get; init; }
    }
}