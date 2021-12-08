namespace DotNetBungieAPI.Services.Default.ServiceConfigurations;

public sealed class DotNetBungieApiDefaultDefinitionProviderConfiguration
{
    private string _manifestFolderPath;
    private string _preferredManifestVersion;

    public string ManifestFolderPath
    {
        get => _manifestFolderPath;
        set => _manifestFolderPath = Conditions.NotNullOrWhiteSpace(value);
    }

    public bool TryLoadExactVersion { get; set; } = false;

    public string PreferredManifestVersion
    {
        get => _preferredManifestVersion;
        set => _preferredManifestVersion = Conditions.NotNullOrWhiteSpace(value);
    }

    public bool FetchLatestManifestOnInitialize { get; set; } = true;
    public bool AutoUpdateManifestOnStartup { get; set; } = false;
    public bool DeleteOldManifestDataAfterUpdates { get; set; } = false;
}