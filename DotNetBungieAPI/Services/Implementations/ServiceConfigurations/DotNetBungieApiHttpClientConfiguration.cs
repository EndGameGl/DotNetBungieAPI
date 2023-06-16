using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using DotNetBungieAPI.Service.Abstractions;

namespace DotNetBungieAPI.Services.Implementations.ServiceConfigurations;

/// <summary>
///     <see cref="IDotNetBungieApiHttpClient"/> configuration
/// </summary>
public sealed class DotNetBungieApiHttpClientConfiguration
{
    /// <summary>
    ///     Use this on SocketsHttpHandler to get IPv4 only
    /// </summary>
    public static Func<
        SocketsHttpConnectionContext,
        CancellationToken,
        ValueTask<Stream>
    > DefaultConnectCallback
    { get; } =
        async (context, cancellationToken) =>
        {
            IPHostEntry ipHostEntry = await Dns.GetHostEntryAsync(
                context.DnsEndPoint.Host,
                cancellationToken
            );
            IPAddress? ipAddress =
                ipHostEntry.AddressList.FirstOrDefault(
                    i => i.AddressFamily is AddressFamily.InterNetwork
                ) ?? throw new Exception($"No IP4 address for {context.DnsEndPoint.Host}");
            TcpClient tcp = new();
            await tcp.ConnectAsync(ipAddress, context.DnsEndPoint.Port, cancellationToken);
            return tcp.GetStream();
        };

    public DotNetBungieApiHttpClientConfiguration() { }

    internal HttpClient? _overrideHttpClient;

    /// <summary>
    ///     Additional configs for http handler
    /// </summary>
    public Action<SocketsHttpHandler>? ConfigureHttpHandler { get; set; }

    /// <summary>
    ///     HttpClient that is used for this lib
    /// </summary>
    public Action<HttpClient>? ConfigureHttpClient { get; set; }

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
        _overrideHttpClient = Conditions.NotNull(httpClient);
    }

    /// <summary>
    ///     Sets settings for api ratelimiting
    /// </summary>
    /// <param name="rateLimitPerInterval"></param>
    /// <param name="interval"></param>
    public void SetRateLimitSettings(int rateLimitPerInterval, TimeSpan interval)
    {
        RateLimitPerInterval = Conditions.Int32MoreThan(rateLimitPerInterval, 0);
        RateLimitInterval = interval;
    }
}
