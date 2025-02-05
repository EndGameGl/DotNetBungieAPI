using System.Text.RegularExpressions;

namespace DotNetBungieAPI;

/// <summary>
///     Static class for working with string variables
/// </summary>
public static partial class StringVariableHelpers
{
    [GeneratedRegex(@"\{var\:\d+\}")]
    private static partial Regex GetStringVariableRegex();

    /// <summary>
    ///     Regex for finding string variables
    /// </summary>
    private static readonly Regex StringVariableRegex = GetStringVariableRegex();

    /// <summary>
    ///     Tries to get string variable hash from a string
    /// </summary>
    /// <param name="value"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    public static bool TryGetStringVariableHash(
        this string value,
        out uint hash
    )
    {
        hash = 0;
        
        if (string.IsNullOrEmpty(value))
            return false;

        var match = StringVariableRegex.Match(value);

        if (!match.Success)
            return false;

        ReadOnlySpan<char> variableString = match.Value;
        var hashString = variableString.Slice(5, variableString.Length - 6);

        return uint.TryParse(hashString, out hash);
    }

    /// <summary>
    ///     Tries to format string based on hash found inside
    /// </summary>
    /// <param name="unformattedString"></param>
    /// <param name="hashes"></param>
    /// <param name="formattedString"></param>
    /// <returns></returns>
    public static bool TryGetStringVariableHashReplaced(
        this string unformattedString,
        IReadOnlyDictionary<uint, int> hashes,
        out string? formattedString
    )
    {
        formattedString = null;
        if (!unformattedString.TryGetStringVariableHash(out var hash))
            return false;

        if (!hashes.TryGetValue(hash, out var hashValue))
            return false;

        formattedString = unformattedString.Replace($"{{var:{hash}}}", hashValue.ToString());
        return true;
    }
}
