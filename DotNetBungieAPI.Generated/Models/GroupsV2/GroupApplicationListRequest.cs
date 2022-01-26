namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationListRequest : IDeepEquatable<GroupApplicationListRequest>
{
    [JsonPropertyName("memberships")]
    public List<User.UserMembership> Memberships { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    public bool DeepEquals(GroupApplicationListRequest? other)
    {
        return other is not null &&
               Memberships.DeepEqualsList(other.Memberships) &&
               Message == other.Message;
    }
}