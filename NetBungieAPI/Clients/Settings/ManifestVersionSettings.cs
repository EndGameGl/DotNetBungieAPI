namespace NetBungieAPI.Clients.Settings
{
    public class ManifestVersionSettings
    {
        public bool ForceLoadManifestVersion { get; internal set; }
        public string PreferredLoadedManifestVersion { get; internal set; }
        public bool KeepOldVersions { get; internal set; }
        public bool CheckUpdates { get; internal set; }

        public static ManifestVersionSettings Default => new ManifestVersionSettings()
        {
            ForceLoadManifestVersion = false,
            PreferredLoadedManifestVersion = null,
            KeepOldVersions = false,
            CheckUpdates = false
        };
    }
}