namespace DotNetBungieAPI.Models.Destiny.Components.Collectibles;

public sealed class DestinyCollectibleComponent
{
    [JsonPropertyName("state")]
    public Destiny.DestinyCollectibleState State { get; init; }
}
