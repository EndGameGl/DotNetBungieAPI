namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupPotentialMembership
{
    [JsonPropertyName("member")]
    public GroupsV2.GroupPotentialMember Member { get; set; }

    [JsonPropertyName("group")]
    public GroupsV2.GroupV2 Group { get; set; }
}
