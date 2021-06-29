using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NetBungieAPI
{
    public static class StringHelpers
    {
        private static readonly Regex _stringVariableRegex = new(@"\{var\:\d+\}");

        public static bool TryGetStringVariableHash(this string value, out uint hash)
        {
            hash = default;

            if (string.IsNullOrEmpty(value))
                return false;

            var match = _stringVariableRegex.Match(value);

            if (!match.Success)
                return false;

            var variableString = match.Value;
            var hashString = variableString.Substring(5, variableString.Length - 6);

            return uint.TryParse(hashString, out hash);
        }

        public static bool TryGetStringVariableHashReplaced(
            this string unformattedString,
            IReadOnlyDictionary<uint, int> hashes,
            out string formattedString)
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
}