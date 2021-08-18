namespace NetBungieAPI.Clients.Settings
{
    /// <summary>
    /// Settings that are used for handling manifest versions
    /// </summary>
    public class ManifestVersionSettings
    {
        /// <summary>
        /// Whether client should ignore all versions and try to load specified one
        /// </summary>
        public bool ForceLoadManifestVersion { get; internal set; }

        /// <summary>
        /// Preferred manifest version to load, if one is specified
        /// </summary>
        public string PreferredLoadedManifestVersion { get; internal set; }

        /// <summary>
        /// Whether client will keep old manifests upon getting new versions
        /// </summary>
        public bool KeepOldVersions { get; internal set; }

        /// <summary>
        /// Whether updates are checked
        /// </summary>
        public bool CheckUpdates { get; internal set; }

        /// <summary>
        /// Default settings
        /// </summary>
        public static ManifestVersionSettings Default => new()
        {
            ForceLoadManifestVersion = false,
            PreferredLoadedManifestVersion = null,
            KeepOldVersions = false,
            CheckUpdates = false
        };
    }
}