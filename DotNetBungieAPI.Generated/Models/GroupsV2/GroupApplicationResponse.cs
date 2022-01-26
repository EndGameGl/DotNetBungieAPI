namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationResponse : IDeepEquatable<GroupApplicationResponse>
{
    [JsonPropertyName("resolution")]
    public GroupsV2.GroupApplicationResolveState Resolution { get; set; }

    public bool DeepEquals(GroupApplicationResponse? other)
    {
        return other is not null &&
               Resolution == other.Resolution;
    }
}