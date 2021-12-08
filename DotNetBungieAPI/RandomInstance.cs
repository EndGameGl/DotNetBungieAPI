using System.Text;

namespace DotNetBungieAPI;

internal static class RandomInstance
{
    private static readonly Random Rnd = new();

    private static readonly char[] Symbols =
        "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

    internal static string GetRandomString(int length = 10)
    {
        if (length <= 0)
            throw new Exception("Invalid string length.");

        var sb = new StringBuilder();
        for (var i = 0; i < length; i++) sb.Append(Symbols[Rnd.Next(Symbols.Length)]);

        return sb.ToString();
    }
}