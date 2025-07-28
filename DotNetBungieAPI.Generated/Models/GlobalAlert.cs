namespace DotNetBungieAPI.Generated.Models;

public class GlobalAlert
{
    [JsonPropertyName("AlertKey")]
    public string AlertKey { get; set; }

    [JsonPropertyName("AlertHtml")]
    public string AlertHtml { get; set; }

    [JsonPropertyName("AlertTimestamp")]
    public DateTime AlertTimestamp { get; set; }

    [JsonPropertyName("AlertLink")]
    public string AlertLink { get; set; }

    [JsonPropertyName("AlertLevel")]
    public GlobalAlertLevel AlertLevel { get; set; }

    [JsonPropertyName("AlertType")]
    public GlobalAlertType AlertType { get; set; }

    [JsonPropertyName("StreamInfo")]
    public StreamInfo? StreamInfo { get; set; }
}
