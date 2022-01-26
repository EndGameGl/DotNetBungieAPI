namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMembershipBase : IDeepEquatable<GroupMembershipBase>
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    public bool DeepEquals(GroupMembershipBase? other)
    {
        return other is not null &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null);
    }
}