namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupMemberLeaveResult
{

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; init; }

    [JsonPropertyName("groupDeleted")]
    public bool GroupDeleted { get; init; }
}
