using System.Runtime.CompilerServices;

namespace DotNetBungieAPI.Models.Extensions;

public static class UInt32Extensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int ToInt32(this uint value) => unchecked((int)value);
}