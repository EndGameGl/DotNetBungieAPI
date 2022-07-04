namespace DotNetBungieAPI.DefinitionProvider.Sqlite;

internal static class Conditions
{
    internal static string NotNullOrWhiteSpace(string? value)
    {
        return !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException();
    }
}