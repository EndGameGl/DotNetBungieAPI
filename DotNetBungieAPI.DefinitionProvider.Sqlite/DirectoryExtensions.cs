namespace DotNetBungieAPI.DefinitionProvider.Sqlite;

internal static class DirectoryExtensions
{
    internal static void EnsureDirectoryExists(this string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
    }
}
