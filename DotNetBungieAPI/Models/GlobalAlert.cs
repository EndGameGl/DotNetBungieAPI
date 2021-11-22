namespace DotNetBungieAPI.Models
{
    public sealed record GlobalAlert
    {
        [JsonPropertyName("AlertKey")] public string AlertKey { get; init; }

        [JsonPropertyName("AlertHtml")] public string AlertHtml { get; init; }

        [JsonPropertyName("AlertTimestamp")] public DateTime AlertTimestamp { get; init; }

        [JsonPropertyName("AlertLink")] public string AlertLink { get; init; }

        [JsonPropertyName("AlertLevel")] public GlobalAlertLevel AlertLevel { get; init; }

        [JsonPropertyName("AlertType")] public GlobalAlertType AlertType { get; init; }

        [JsonPropertyName("StreamInfo")] public StreamInfo StreamInfo { get; init; }
    }
}