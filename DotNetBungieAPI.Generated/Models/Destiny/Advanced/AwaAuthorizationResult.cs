using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaAuthorizationResult
{

    [JsonPropertyName("userSelection")]
    public Destiny.Advanced.AwaUserSelection UserSelection { get; init; }

    [JsonPropertyName("responseReason")]
    public Destiny.Advanced.AwaResponseReason ResponseReason { get; init; }

    [JsonPropertyName("developerNote")]
    public string DeveloperNote { get; init; }

    [JsonPropertyName("actionToken")]
    public string ActionToken { get; init; }

    [JsonPropertyName("maximumNumberOfUses")]
    public int MaximumNumberOfUses { get; init; }

    [JsonPropertyName("validUntil")]
    public DateTime? ValidUntil { get; init; }

    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; init; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
