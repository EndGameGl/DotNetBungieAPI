namespace DotNetBungieAPI.Models.GroupsV2;

public sealed class GroupApplicationListRequest
{
    [JsonPropertyName("memberships")]
    public User.UserMembership[]? Memberships { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; }
}
