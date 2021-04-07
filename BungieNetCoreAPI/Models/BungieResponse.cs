using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models
{
    public sealed record BungieResponse<T>
    {
        [JsonPropertyName("Response")]
        public T Response { get; init; }

        [JsonPropertyName("ErrorCode")]
        public PlatformErrorCodes ErrorCode { get; init; }

        [JsonPropertyName("ThrottleSeconds")]
        public int ThrottleSeconds { get; init; }

        [JsonPropertyName("ErrorStatus")]
        public string ErrorStatus { get; init; }

        [JsonPropertyName("Message")]
        public string Message { get; init; }

        [JsonPropertyName("MessageData")]
        public Dictionary<string, string> MessageData { get; init; }

        [JsonPropertyName("DetailedErrorTrace")]
        public string DetailedErrorTrace { get; init; }

        internal DateTime ResponseDate { get; init; } = DateTime.Now;
    }
}
