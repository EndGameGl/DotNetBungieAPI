namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMembership : IDeepEquatable<GroupMembership>
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupMember Member { get; set; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    public bool DeepEquals(GroupMembership? other)
    {
        return other is not null &&
               (Member is not null ? Member.DeepEquals(other.Member) : other.Member is null) &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null);
    }
}