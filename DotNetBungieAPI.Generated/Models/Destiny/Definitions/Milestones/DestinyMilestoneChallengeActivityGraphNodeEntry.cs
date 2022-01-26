namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Milestones;

public class DestinyMilestoneChallengeActivityGraphNodeEntry : IDeepEquatable<DestinyMilestoneChallengeActivityGraphNodeEntry>
{
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    [JsonPropertyName("activityGraphNodeHash")]
    public uint ActivityGraphNodeHash { get; set; }

    public bool DeepEquals(DestinyMilestoneChallengeActivityGraphNodeEntry? other)
    {
        return other is not null &&
               ActivityGraphHash == other.ActivityGraphHash &&
               ActivityGraphNodeHash == other.ActivityGraphNodeHash;
    }
}