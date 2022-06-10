namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupApplicationListRequest
{
    [JsonPropertyName("memberships")]
    public List<User.UserMembership> Memberships { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
