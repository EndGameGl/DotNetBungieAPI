using System.Runtime.CompilerServices;

namespace DotNetBungieAPI.Models.Extensions;

public static class Int32Extensions
{
    /// <summary>
    ///     Converts <see cref="int" /> hash to <see cref="uint" /> value
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint ToUInt32(this int hash)
    {
        return unchecked((uint)hash);
    }
}
