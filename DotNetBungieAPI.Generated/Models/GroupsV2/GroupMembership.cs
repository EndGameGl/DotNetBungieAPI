namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupMembership
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupMember? Member { get; set; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2? Group { get; set; }
}
