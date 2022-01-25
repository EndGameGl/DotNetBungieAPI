namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

/// <summary>
///     If this record has an expiration after which it cannot be earned, this is some information about that expiration.
/// </summary>
public class DestinyRecordExpirationBlock
{
    [JsonPropertyName("hasExpiration")]
    public bool HasExpiration { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}
