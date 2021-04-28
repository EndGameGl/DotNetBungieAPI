using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Responses
{
    public sealed record AwaInitializeResponse
    {
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; init; }
        
        [JsonPropertyName("sentToSelf")]
        public bool SentToSelf { get; init; }
    }
}