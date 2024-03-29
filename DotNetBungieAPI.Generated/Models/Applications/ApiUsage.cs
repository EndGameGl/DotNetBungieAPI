namespace DotNetBungieAPI.Generated.Models.Applications;

public class ApiUsage
{
    /// <summary>
    ///     Counts for on API calls made for the time range.
    /// </summary>
    [JsonPropertyName("apiCalls")]
    public List<Applications.Series> ApiCalls { get; set; }

    /// <summary>
    ///     Instances of blocked requests or requests that crossed the warn threshold during the time range.
    /// </summary>
    [JsonPropertyName("throttledRequests")]
    public List<Applications.Series> ThrottledRequests { get; set; }
}
