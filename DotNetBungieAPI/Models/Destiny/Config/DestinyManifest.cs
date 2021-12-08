using System.Text.RegularExpressions;

namespace DotNetBungieAPI.Models.Destiny.Config;

/// <summary>
///     DestinyManifest is the external-facing contract for just the properties needed by those calling the Destiny
///     Platform.
/// </summary>
public sealed record DestinyManifest
{
    private readonly string _version;
    private DateTime _versionDate;

    [JsonPropertyName("version")]
    public string Version
    {
        get => _version;
        init
        {
            _version = value;
            TryParseDate(value, out _versionDate);
        }
    }

    [JsonPropertyName("mobileAssetContentPath")]
    public string MobileAssetContentPath { get; init; }

    [JsonPropertyName("mobileGearAssetDataBases")]
    public ReadOnlyCollection<MobileGearAssetDataBaseEntry> MobileGearAssetDataBases { get; init; }

    [JsonPropertyName("mobileWorldContentPaths")]
    public ReadOnlyDictionary<string, string> MobileWorldContentPaths { get; init; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a path to
    ///     the aggregated world definitions (warning: large file!)
    /// </summary>
    [JsonPropertyName("jsonWorldContentPaths")]
    public ReadOnlyDictionary<string, string> JsonWorldContentPaths { get; init; }

    /// <summary>
    ///     This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a
    ///     dictionary, where the key is a definition type by name, and the value is the path to the file for that definition.
    ///     <para />
    ///     WARNING: This is unsafe and subject to change - do not depend on data in these files staying around long-term.
    /// </summary>
    [JsonPropertyName("jsonWorldComponentContentPaths")]
    public ReadOnlyDictionary<string, ReadOnlyDictionary<string, string>> JsonWorldComponentContentPaths { get; init; }

    [JsonPropertyName("mobileClanBannerDatabasePath")]
    public string MobileClanBannerDatabasePath { get; init; }

    [JsonPropertyName("mobileGearCDN")] public ReadOnlyDictionary<string, string> MobileGearCDN { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public DateTime VersionDate
    {
        get => _versionDate;
        private set => _versionDate = value;
    }

    public bool Equals(DestinyManifest manifest)
    {
        return Version == manifest.Version;
    }

    private static bool TryParseDate(string version, out DateTime date)
    {
        date = DateTime.MinValue;
        if (string.IsNullOrWhiteSpace(version))
            return false;
        var rgx = new Regex(@"\.\d{2}\.\d{2}\.\d{2}\.");
        var match = rgx.Match(version);
        if (match.Success)
        {
            var valuesArray = match.ToString().Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (valuesArray.Length == 3)
            {
                var year = 2000 + int.Parse(valuesArray[0]);
                var month = int.Parse(valuesArray[1]);
                var day = int.Parse(valuesArray[2]);
                date = new DateTime(year, month, day);
                return true;
            }

            return false;
        }

        return false;
    }
}