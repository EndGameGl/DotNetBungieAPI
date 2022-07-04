using System.Net.Http;

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
    public int RatelimitPerInterval { get; internal set; } = 250;
    
    /// <summary>
    ///     Ratelimit interval
    ///     <para/>
    ///     Default is 10 seconds.
    /// </summary>
    public TimeSpan RatelimitInterval { get; internal set; } = TimeSpan.FromSeconds(10);

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
    /// <param name="ratelimitPerInterval"></param>
    /// <param name="interval"></param>
    public void SetRatelimitSettings(
        int ratelimitPerInterval,
        TimeSpan interval)
    {
        RatelimitPerInterval = Conditions.Int32MoreThan(ratelimitPerInterval, 0);
        RatelimitInterval = interval;
    }
}