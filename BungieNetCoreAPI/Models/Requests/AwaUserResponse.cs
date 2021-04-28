using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Requests
{
    public class AwaUserResponse
    {
        [JsonPropertyName("selection")]
        public AwaUserSelection Selection { get; }
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; }
        [JsonPropertyName("nonce")]
        public byte[] Nonce { get; }

        public AwaUserResponse(AwaUserSelection selection, string correlationId, byte[] nonce)
        {
            Selection = selection;
            CorrelationId = correlationId;
            Nonce = nonce;
        }
    }
}