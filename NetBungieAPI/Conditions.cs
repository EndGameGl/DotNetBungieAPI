using System;

namespace NetBungieAPI
{
    internal static class Conditions
    {
        internal static string NotNullOrWhiteSpace(string value) =>
            !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException();

        internal static int Int32MoreThan(int value, int comparedAgainst) =>
            value > comparedAgainst ? value : throw new ArgumentException();

        internal static T NotNull<T>(T value) =>
            value is not null ? value : throw new ArgumentNullException(nameof(value));
    }
}