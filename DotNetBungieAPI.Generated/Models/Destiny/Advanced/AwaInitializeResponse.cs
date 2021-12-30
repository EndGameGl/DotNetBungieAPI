using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaInitializeResponse
{

    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; init; }

    [JsonPropertyName("sentToSelf")]
    public bool SentToSelf { get; init; }
}
