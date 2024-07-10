namespace DotNetBungieAPI;

internal static class Conditions
{
    internal static string NotNullOrWhiteSpace(string value)
    {
        return !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException();
    }

    internal static int Int32MoreThan(int value, int comparedAgainst)
    {
        return value > comparedAgainst ? value : throw new ArgumentException();
    }

    internal static T NotNull<T>(T value)
    {
        return value is not null ? value : throw new ArgumentNullException(nameof(value));
    }
}
