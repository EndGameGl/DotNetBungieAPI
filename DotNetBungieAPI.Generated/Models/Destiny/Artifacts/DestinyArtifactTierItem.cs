namespace DotNetBungieAPI.Generated.Models.Destiny.Artifacts;

public class DestinyArtifactTierItem : IDeepEquatable<DestinyArtifactTierItem>
{
    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; }

    public bool DeepEquals(DestinyArtifactTierItem? other)
    {
        return other is not null &&
               ItemHash == other.ItemHash &&
               IsActive == other.IsActive;
    }
}