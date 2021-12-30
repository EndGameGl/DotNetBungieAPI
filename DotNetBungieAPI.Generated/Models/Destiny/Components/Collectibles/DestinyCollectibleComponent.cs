using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public sealed class DestinyCollectibleComponent
{

    [JsonPropertyName("state")]
    public Destiny.DestinyCollectibleState State { get; init; }
}
