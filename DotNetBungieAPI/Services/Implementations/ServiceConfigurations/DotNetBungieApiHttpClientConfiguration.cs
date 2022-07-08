using System.Net.Http;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Services.Implementations.ServiceConfigurations;

/// <summary>
///     <see cref="IDotNetBungieApiHttpClient"/> configuration
/// </summary>
public sealed class DotNetBungieApiHttpClientConfiguration
{
    public DotNetBungieApiHttpClientConfiguration()
    {
        var httpClientHandler = new HttpClientHandler();
        HttpClient = new HttpClient(httpClientHandler);
    }

    /// <summary>
    ///     HttpClient that is used for this lib
    /// </summary>
    public HttpClient HttpClient { get; internal set; }

    /// <summary>
    ///     Ratelimit that is used for interval
    ///     <para/>
    ///     Default is 250.
    /// </summary>
    public int RateLimitPerInterval { get; internal set; } = 220;

    /// <summary>
    ///     Ratelimit interval
    ///     <para/>
    ///     Default is 10 seconds.
    /// </summary>
    public TimeSpan RateLimitInterval { get; internal set; } = TimeSpan.FromSeconds(10);

    private int _maxConcurrentRequestsAtOnce = 25;

    /// <summary>
    ///     Maximum allowed amount of concurrent requests
    /// <para/>
    ///     Default is 25
    /// </summary>
    public int MaxConcurrentRequestsAtOnce
    {
        get => _maxConcurrentRequestsAtOnce;
        set => _maxConcurrentRequestsAtOnce = Conditions.Int32MoreThan(value, 0);
    }

    private int _maxRequestsPerSecond = 25;

    /// <summary>
    ///     Maximum allowed amount of requests that can be made per second
    /// <para/>
    ///     Default is 25
    /// </summary>
    public int MaxRequestsPerSecond
    {
        get => _maxRequestsPerSecond;
        set => _maxRequestsPerSecond = Conditions.Int32MoreThan(value, 0);
    }

    /// <summary>
    ///     Uses external <see cref="HttpClient"/> for this app
    /// </summary>
    /// <param name="httpClient"></param>
    public void UseExternalHttpClient(HttpClient httpClient)
    {
        HttpClient = Conditions.NotNull(httpClient);
    }

    /// <summary>
    ///     Sets settings for api ratelimiting
    /// </summary>
    /// <param name="rateLimitPerInterval"></param>
    /// <param name="interval"></param>
    public void SetRateLimitSettings(
        int rateLimitPerInterval,
        TimeSpan interval)
    {
        RateLimitPerInterval = Conditions.Int32MoreThan(rateLimitPerInterval, 0);
        RateLimitInterval = interval;
    }
}