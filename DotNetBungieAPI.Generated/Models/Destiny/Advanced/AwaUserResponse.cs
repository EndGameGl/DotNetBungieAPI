using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaUserResponse
{

    [JsonPropertyName("selection")]
    public Destiny.Advanced.AwaUserSelection Selection { get; init; }

    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; init; }

    [JsonPropertyName("nonce")]
    public List<string> Nonce { get; init; }
}
