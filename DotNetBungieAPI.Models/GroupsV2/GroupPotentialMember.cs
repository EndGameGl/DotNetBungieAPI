namespace DotNetBungieAPI.Models.GroupsV2;

public sealed record GroupPotentialMember : GroupUserBase
{
    [JsonPropertyName("potentialStatus")]
    public GroupPotentialMemberStatus PotentialStatus { get; init; }
}
