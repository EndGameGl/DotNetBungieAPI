namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupNameSearchRequest
{
    [JsonPropertyName("groupName")]
    public string GroupName { get; init; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; init; }
}
