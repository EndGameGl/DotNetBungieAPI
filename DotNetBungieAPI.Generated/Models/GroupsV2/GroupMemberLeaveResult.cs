namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMemberLeaveResult : IDeepEquatable<GroupMemberLeaveResult>
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    [JsonPropertyName("groupDeleted")]
    public bool GroupDeleted { get; set; }

    public bool DeepEquals(GroupMemberLeaveResult? other)
    {
        return other is not null &&
               (Group is not null ? Group.DeepEquals(other.Group) : other.Group is null) &&
               GroupDeleted == other.GroupDeleted;
    }
}