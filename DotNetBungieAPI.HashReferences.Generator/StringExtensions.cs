namespace DotNetBungieAPI.HashReferences.Generator;

public static class StringExtensions
{
    internal static string GetIndentedString(int level, string text)
    {
        return $"{GetIndent(level)}{text}";
    }

    internal static string GetIndent(int level)
    {
        return new string(Helpers.Tabulation, level);
    }
}
