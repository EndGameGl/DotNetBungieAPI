namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupNameSearchRequest : IDeepEquatable<GroupNameSearchRequest>
{
    [JsonPropertyName("groupName")]
    public string GroupName { get; set; }

    [JsonPropertyName("groupType")]
    public GroupsV2.GroupType GroupType { get; set; }

    public bool DeepEquals(GroupNameSearchRequest? other)
    {
        return other is not null &&
               GroupName == other.GroupName &&
               GroupType == other.GroupType;
    }
}