using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

/// <summary>
///     If this record has an expiration after which it cannot be earned, this is some information about that expiration.
/// </summary>
public sealed class DestinyRecordExpirationBlock
{

    [JsonPropertyName("hasExpiration")]
    public bool HasExpiration { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("icon")]
    public string Icon { get; init; }
}
