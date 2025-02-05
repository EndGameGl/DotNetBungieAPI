﻿

namespace DotNetBungieAPI.Models.Applications;

public sealed record ApiUsage
{
    /// <summary>
    ///     Counts for on API calls made for the time range.
    /// </summary>
    [JsonPropertyName("apiCalls")]
    public ReadOnlyCollection<Series> ApiCalls { get; init; } = ReadOnlyCollection<Series>.Empty;

    /// <summary>
    ///     Instances of blocked requests or requests that crossed the warn threshold during the time range.
    /// </summary>
    [JsonPropertyName("throttledRequests")]
    public ReadOnlyCollection<Series> ThrottledRequests { get; init; } =
        ReadOnlyCollection<Series>.Empty;
}
