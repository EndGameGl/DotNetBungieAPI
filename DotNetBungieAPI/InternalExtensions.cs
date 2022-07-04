using System.Runtime.CompilerServices;
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
    internal static string ComponentsToWordString(this IEnumerable<DestinyComponentType> componentTypes)
    {
        return string.Join(',', componentTypes);
    }

    /// <summary>
    ///     Converts destiny component types to query string
    /// </summary>
    /// <param name="componentTypes"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string ComponentsToIntString(this IEnumerable<DestinyComponentType> componentTypes)
    {
        return string.Join(',', componentTypes.Select(x => (int)x));
    }
}