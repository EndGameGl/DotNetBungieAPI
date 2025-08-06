namespace DotNetBungieAPI.Models.Applications;

public sealed class ApiUsage
{
    /// <summary>
    ///     Counts for on API calls made for the time range.
    /// </summary>
    [JsonPropertyName("apiCalls")]
    public Applications.Series[]? ApiCalls { get; init; }

    /// <summary>
    ///     Instances of blocked requests or requests that crossed the warn threshold during the time range.
    /// </summary>
    [JsonPropertyName("throttledRequests")]
    public Applications.Series[]? ThrottledRequests { get; init; }
}
