namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMemberLeaveResult
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }

    [JsonPropertyName("groupDeleted")]
    public bool GroupDeleted { get; set; }
}
