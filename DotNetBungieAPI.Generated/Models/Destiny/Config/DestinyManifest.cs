using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Config;

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

    [JsonPropertyName("jsonWorldContentPaths")]
    public Dictionary<string, string> JsonWorldContentPaths { get; init; }

    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; init; }

    [JsonPropertyName("mobileClanBannerDatabasePath")]
    public string MobileClanBannerDatabasePath { get; init; }

    [JsonPropertyName("mobileGearCDN")]
    public Dictionary<string, string> MobileGearCDN { get; init; }

    [JsonPropertyName("iconImagePyramidInfo")]
    public List<Destiny.Config.ImagePyramidEntry> IconImagePyramidInfo { get; init; }
}
