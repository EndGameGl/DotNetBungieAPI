namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupMembership
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupMember? Member { get; init; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2? Group { get; init; }
}
