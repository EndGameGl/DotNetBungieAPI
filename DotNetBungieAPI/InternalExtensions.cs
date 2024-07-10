using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI;

internal static class InternalExtensions
{
    /// <summary>
    ///     Converts destiny component types to query string
    /// </summary>
    /// <param name="componentTypes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string ComponentsToWordString(
        this IEnumerable<DestinyComponentType> componentTypes
    )
    {
        return string.Join(',', componentTypes);
    }

    /// <summary>
    ///     Converts destiny component types to query string
    /// </summary>
    /// <param name="componentTypes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string ComponentsToIntString(
        this IEnumerable<DestinyComponentType> componentTypes
    )
    {
        return string.Join(',', componentTypes.Select(x => (int)x));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<(long, TResponse response)> MeasureAsync<TResponse>(
        Func<Task<TResponse>> task
    )
    {
        var start = Stopwatch.GetTimestamp();
        var result = await task();
        var end = Stopwatch.GetTimestamp();
        return (end - start, result);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<long> MeasureAsync(Func<Task> task)
    {
        var start = Stopwatch.GetTimestamp();
        await task();
        var end = Stopwatch.GetTimestamp();
        return end - start;
    }

    internal static double TicksToSeconds(this long ticks) => ticks / 10_000_000;
}
