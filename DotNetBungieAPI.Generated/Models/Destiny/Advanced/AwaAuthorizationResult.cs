namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaAuthorizationResult
{

    /// <summary>
    ///     Indication of how the user responded to the request. If the value is "Approved" the actionToken will contain the token that can be presented when performing the advanced write action.
    /// </summary>
    [JsonPropertyName("userSelection")]
    public Destiny.Advanced.AwaUserSelection UserSelection { get; init; }

    [JsonPropertyName("responseReason")]
    public Destiny.Advanced.AwaResponseReason ResponseReason { get; init; }

    /// <summary>
    ///     Message to the app developer to help understand the response.
    /// </summary>
    [JsonPropertyName("developerNote")]
    public string DeveloperNote { get; init; }

    /// <summary>
    ///     Credential used to prove the user authorized an advanced write action.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; init; }

    /// <summary>
    ///     This token may be used to perform the requested action this number of times, at a maximum. If this value is 0, then there is no limit.
    /// </summary>
    [JsonPropertyName("maximumNumberOfUses")]
    public int MaximumNumberOfUses { get; init; }

    /// <summary>
    ///     Time, UTC, when token expires.
    /// </summary>
    [JsonPropertyName("validUntil")]
    public DateTime? ValidUntil { get; init; }

    /// <summary>
    ///     Advanced Write Action Type from the permission request.
    /// </summary>
    [JsonPropertyName("type")]
    public Destiny.Advanced.AwaType Type { get; init; }

    /// <summary>
    ///     MembershipType from the permission request.
    /// </summary>
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; init; }
}
