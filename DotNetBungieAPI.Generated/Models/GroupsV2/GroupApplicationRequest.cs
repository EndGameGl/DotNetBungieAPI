namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationRequest : IDeepEquatable<GroupApplicationRequest>
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    public bool DeepEquals(GroupApplicationRequest? other)
    {
        return other is not null &&
               Message == other.Message;
    }
}