using NetBungieAPI.Models.User;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Queries
{
    public class GroupApplicationListRequest
    {
        [JsonPropertyName("memberships")]
        public List<UserMembership> Memberships { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }
}
