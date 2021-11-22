using DotNetBungieAPI.Models.User;

namespace DotNetBungieAPI.Models.Queries
{
    public class GroupApplicationListRequest
    {
        [JsonPropertyName("memberships")] public List<UserMembership> Memberships { get; init; }

        [JsonPropertyName("message")] public string Message { get; init; }
    }
}