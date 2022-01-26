namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

/// <summary>
///     If this record has an expiration after which it cannot be earned, this is some information about that expiration.
/// </summary>
public class DestinyRecordExpirationBlock : IDeepEquatable<DestinyRecordExpirationBlock>
{
    [JsonPropertyName("hasExpiration")]
    public bool HasExpiration { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    public bool DeepEquals(DestinyRecordExpirationBlock? other)
    {
        return other is not null &&
               HasExpiration == other.HasExpiration &&
               Description == other.Description &&
               Icon == other.Icon;
    }
}