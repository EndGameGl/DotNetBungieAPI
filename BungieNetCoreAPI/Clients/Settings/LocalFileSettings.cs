namespace NetBungieAPI.Clients.Settings
{
    public class LocalFileSettings
    {
        public string VersionsRepositoryPath { get; internal set; }

        public static LocalFileSettings Default => new()
        {
            VersionsRepositoryPath = null
        };
    }
}