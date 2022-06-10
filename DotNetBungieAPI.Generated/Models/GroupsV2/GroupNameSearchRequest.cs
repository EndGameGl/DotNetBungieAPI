namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupNameSearchRequest
{
    [JsonPropertyName("groupName")]
    public string? GroupName { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType? GroupType { get; set; }
}
