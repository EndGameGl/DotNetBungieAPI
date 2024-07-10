using System.Runtime.CompilerServices;

namespace DotNetBungieAPI.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<TTo> UnsafeCast<TFrom, TTo>(this IEnumerable<TFrom> source)
    {
        foreach (var type in source)
        {
            var variable = type;
            yield return Unsafe.As<TFrom, TTo>(ref variable);
        }
    }
}
