namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupPotentialMembership
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupPotentialMember? Member { get; init; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2? Group { get; init; }
}
