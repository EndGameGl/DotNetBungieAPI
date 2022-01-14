namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public sealed class GroupApplicationListRequest
{

    [JsonPropertyName("memberships")]
    public List<User.UserMembership> Memberships { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; }
}
