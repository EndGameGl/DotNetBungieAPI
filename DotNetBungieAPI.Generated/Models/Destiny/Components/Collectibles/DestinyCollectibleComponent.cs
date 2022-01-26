namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyCollectibleComponent : IDeepEquatable<DestinyCollectibleComponent>
{
    [JsonPropertyName("state")]
    public Destiny.DestinyCollectibleState State { get; set; }

    public bool DeepEquals(DestinyCollectibleComponent? other)
    {
        return other is not null &&
               State == other.State;
    }
}