using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.User
{
    public record UserMembership
    {
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }

        [JsonPropertyName("membershipId"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long MembershipId { get; init; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }
    }
}
