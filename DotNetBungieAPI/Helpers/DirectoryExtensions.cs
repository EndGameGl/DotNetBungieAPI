using System.IO;

namespace DotNetBungieAPI.Helpers
{
    internal static class DirectoryExtensions
    {
        internal static void EnsureDirectoryExists(this string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}