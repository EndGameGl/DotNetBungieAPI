namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

/// <summary>
///     If this record has an expiration after which it cannot be earned, this is some information about that expiration.
/// </summary>
public sealed record DestinyRecordExpirationBlock : IDeepEquatable<DestinyRecordExpirationBlock>
{
    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("hasExpiration")]
    public bool HasExpiration { get; init; }

    [JsonPropertyName("icon")]
    public BungieNetResource Icon { get; init; }

    public bool DeepEquals(DestinyRecordExpirationBlock other)
    {
        return other != null
            && Description == other.Description
            && HasExpiration == other.HasExpiration
            && Icon == other.Icon;
    }
}
