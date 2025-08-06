namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupMembershipBase
{
    [JsonPropertyName("group")]
    public GroupsV2.GroupV2? Group { get; init; }
}
