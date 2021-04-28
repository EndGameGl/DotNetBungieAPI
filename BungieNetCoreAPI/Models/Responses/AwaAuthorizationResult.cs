using System;
using System.Text.Json.Serialization;
using NetBungieAPI.Models.Requests;

namespace NetBungieAPI.Models.Responses
{
    public sealed record AwaAuthorizationResult
    {
        [JsonPropertyName("userSelection")]
        public AwaUserSelection UserSelection { get; init; }
        [JsonPropertyName("responseReason")]
        public AwaResponseReason ResponseReason { get; init; }
        [JsonPropertyName("developerNote")]
        public string DeveloperNote { get; init; }
        [JsonPropertyName("actionToken")]
        public string ActionToken { get; init; }
        [JsonPropertyName("maximumNumberOfUses")]
        public int MaximumNumberOfUses { get; init; }
        [JsonPropertyName("validUntil")]
        public DateTime? ValidUntil { get; init; }
        [JsonPropertyName("type")]
        public AwaType Type { get; init; }
        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; init; }
    }
}