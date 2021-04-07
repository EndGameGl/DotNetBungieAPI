using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Applications
{
    public sealed record Datapoint
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; init; }

        [JsonPropertyName("count")]
        public double? Count { get; init; }
    }
}
