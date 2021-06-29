using System.Collections.Generic;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.User;

namespace NetBungieAPI.Models.Queries
{
    public class GroupApplicationListRequest
    {
        [JsonPropertyName("memberships")] public List<UserMembership> Memberships { get; init; }

        [JsonPropertyName("message")] public string Message { get; init; }
    }
}