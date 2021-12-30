using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

/// <summary>
///     DestinyManifest is the external-facing contract for just the properties needed by those calling the Destiny Platform.
/// </summary>
public sealed class DestinyManifest
{

    [JsonPropertyName("version")]
    public string Version { get; init; }

    [JsonPropertyName("mobileAssetContentPath")]
    public string MobileAssetContentPath { get; init; }

    [JsonPropertyName("mobileGearAssetDataBases")]
    public List<Destiny.Config.GearAssetDataBaseDefinition> MobileGearAssetDataBases { get; init; }

    [JsonPropertyName("mobileWorldContentPaths")]
    public Dictionary<string, string> MobileWorldContentPaths { get; init; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a path to the aggregated world definitions (warning: large file!)
    /// </summary>
    [JsonPropertyName("jsonWorldContentPaths")]
    public Dictionary<string, string> JsonWorldContentPaths { get; init; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a dictionary, where the key is a definition type by name, and the value is the path to the file for that definition. WARNING: This is unsafe and subject to change - do not depend on data in these files staying around long-term.
    /// </summary>
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; init; }

    [JsonPropertyName("mobileClanBannerDatabasePath")]
    public string MobileClanBannerDatabasePath { get; init; }

    [JsonPropertyName("mobileGearCDN")]
    public Dictionary<string, string> MobileGearCDN { get; init; }

    /// <summary>
    ///     Information about the "Image Pyramid" for Destiny icons. Where possible, we create smaller versions of Destiny icons. These are found as subfolders under the location of the "original/full size" Destiny images, with the same file name and extension as the original image itself. (this lets us avoid sending largely redundant path info with every entity, at the expense of the smaller versions of the image being less discoverable)
    /// </summary>
    [JsonPropertyName("iconImagePyramidInfo")]
    public List<Destiny.Config.ImagePyramidEntry> IconImagePyramidInfo { get; init; }
}
