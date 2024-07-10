using System.Threading;
using System.Threading.Tasks;
using ComposableAsync;
using Microsoft.Extensions.Logging;
using RateLimiter;

namespace DotNetBungieAPI.RateLimiting;

/// <summary>
///     This class is supposed to limit outgoing bungie.net requests
/// </summary>
internal sealed class ApiRateLimiter
{
    private readonly ILogger _logger;
    private readonly SemaphoreSlim _concurrentCallsSemaphore;

    private readonly TimeLimiter _rateLimiter;

    /// <summary>
    ///     .ctor
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="requestsLimit">Global requests limit per time frame</param>
    /// <param name="requestsLimitTimeFrame">Global requests limit time interval</param>
    /// <param name="perSecondMaxLimit">Limit per second for requests</param>
    /// <param name="maxConcurrentRequestsLimit">Maximum amount of concurrent requests</param>
    internal ApiRateLimiter(
        ILogger logger,
        int requestsLimit,
        TimeSpan requestsLimitTimeFrame,
        int perSecondMaxLimit,
        int maxConcurrentRequestsLimit
    )
    {
        _logger = logger;
        _concurrentCallsSemaphore = new SemaphoreSlim(
            maxConcurrentRequestsLimit,
            maxConcurrentRequestsLimit
        );

        var localSecondConstraint = new CountByIntervalAwaitableConstraint(
            perSecondMaxLimit,
            TimeSpan.FromSeconds(1)
        );

        var globalRequestConstraint = new CountByIntervalAwaitableConstraint(
            requestsLimit,
            requestsLimitTimeFrame
        );

        _rateLimiter = TimeLimiter.Compose(globalRequestConstraint, localSecondConstraint);
    }

    /// <summary>
    ///     Waits for task execution with respect to bungie.net api rate limits
    /// </summary>
    /// <param name="func">Call to execute</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="T">Return type</typeparam>
    /// <returns></returns>
    public async Task<T> WaitAndRunAsync<T>(
        Func<CancellationToken, Task<T>> func,
        CancellationToken cancellationToken
    )
    {
        await _concurrentCallsSemaphore.WaitAsync(cancellationToken);
        await _rateLimiter;
        try
        {
            return await func(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(
                exception,
                "Failed to execute task within rate limiter: {ErrorMessage}",
                exception.Message
            );
            throw;
        }
        finally
        {
            _concurrentCallsSemaphore.Release();
        }
    }
}
