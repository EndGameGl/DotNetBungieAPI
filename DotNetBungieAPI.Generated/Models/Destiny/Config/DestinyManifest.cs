namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

/// <summary>
///     DestinyManifest is the external-facing contract for just the properties needed by those calling the Destiny Platform.
/// </summary>
public class DestinyManifest : IDeepEquatable<DestinyManifest>
{
    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("mobileAssetContentPath")]
    public string MobileAssetContentPath { get; set; }

    [JsonPropertyName("mobileGearAssetDataBases")]
    public List<Destiny.Config.GearAssetDataBaseDefinition> MobileGearAssetDataBases { get; set; }

    [JsonPropertyName("mobileWorldContentPaths")]
    public Dictionary<string, string> MobileWorldContentPaths { get; set; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a path to the aggregated world definitions (warning: large file!)
    /// </summary>
    [JsonPropertyName("jsonWorldContentPaths")]
    public Dictionary<string, string> JsonWorldContentPaths { get; set; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a dictionary, where the key is a definition type by name, and the value is the path to the file for that definition. WARNING: This is unsafe and subject to change - do not depend on data in these files staying around long-term.
    /// </summary>
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; set; }

    [JsonPropertyName("mobileClanBannerDatabasePath")]
    public string MobileClanBannerDatabasePath { get; set; }

    [JsonPropertyName("mobileGearCDN")]
    public Dictionary<string, string> MobileGearCDN { get; set; }

    /// <summary>
    ///     Information about the "Image Pyramid" for Destiny icons. Where possible, we create smaller versions of Destiny icons. These are found as subfolders under the location of the "original/full size" Destiny images, with the same file name and extension as the original image itself. (this lets us avoid sending largely redundant path info with every entity, at the expense of the smaller versions of the image being less discoverable)
    /// </summary>
    [JsonPropertyName("iconImagePyramidInfo")]
    public List<Destiny.Config.ImagePyramidEntry> IconImagePyramidInfo { get; set; }

    public bool DeepEquals(DestinyManifest? other)
    {
        return other is not null &&
               Version == other.Version &&
               MobileAssetContentPath == other.MobileAssetContentPath &&
               MobileGearAssetDataBases.DeepEqualsList(other.MobileGearAssetDataBases) &&
               MobileWorldContentPaths.DeepEqualsDictionaryNaive(other.MobileWorldContentPaths) &&
               JsonWorldContentPaths.DeepEqualsDictionaryNaive(other.JsonWorldContentPaths) &&
               JsonWorldComponentContentPaths.DeepEqualsDictionaryNaive(other.JsonWorldComponentContentPaths) &&
               MobileClanBannerDatabasePath == other.MobileClanBannerDatabasePath &&
               MobileGearCDN.DeepEqualsDictionaryNaive(other.MobileGearCDN) &&
               IconImagePyramidInfo.DeepEqualsList(other.IconImagePyramidInfo);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyManifest? other)
    {
        if (other is null) return;
        if (Version != other.Version)
        {
            Version = other.Version;
            OnPropertyChanged(nameof(Version));
        }
        if (MobileAssetContentPath != other.MobileAssetContentPath)
        {
            MobileAssetContentPath = other.MobileAssetContentPath;
            OnPropertyChanged(nameof(MobileAssetContentPath));
        }
        if (!MobileGearAssetDataBases.DeepEqualsList(other.MobileGearAssetDataBases))
        {
            MobileGearAssetDataBases = other.MobileGearAssetDataBases;
            OnPropertyChanged(nameof(MobileGearAssetDataBases));
        }
        if (!MobileWorldContentPaths.DeepEqualsDictionaryNaive(other.MobileWorldContentPaths))
        {
            MobileWorldContentPaths = other.MobileWorldContentPaths;
            OnPropertyChanged(nameof(MobileWorldContentPaths));
        }
        if (!JsonWorldContentPaths.DeepEqualsDictionaryNaive(other.JsonWorldContentPaths))
        {
            JsonWorldContentPaths = other.JsonWorldContentPaths;
            OnPropertyChanged(nameof(JsonWorldContentPaths));
        }
        if (!JsonWorldComponentContentPaths.DeepEqualsDictionary(other.JsonWorldComponentContentPaths))
        {
            JsonWorldComponentContentPaths = other.JsonWorldComponentContentPaths;
            OnPropertyChanged(nameof(JsonWorldComponentContentPaths));
        }
        if (MobileClanBannerDatabasePath != other.MobileClanBannerDatabasePath)
        {
            MobileClanBannerDatabasePath = other.MobileClanBannerDatabasePath;
            OnPropertyChanged(nameof(MobileClanBannerDatabasePath));
        }
        if (!MobileGearCDN.DeepEqualsDictionaryNaive(other.MobileGearCDN))
        {
            MobileGearCDN = other.MobileGearCDN;
            OnPropertyChanged(nameof(MobileGearCDN));
        }
        if (!IconImagePyramidInfo.DeepEqualsList(other.IconImagePyramidInfo))
        {
            IconImagePyramidInfo = other.IconImagePyramidInfo;
            OnPropertyChanged(nameof(IconImagePyramidInfo));
        }
    }
}