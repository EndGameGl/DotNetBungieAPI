using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyDisplayCategoryDefinition
{

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("identifier")]
    public string Identifier { get; init; }

    [JsonPropertyName("displayCategoryHash")]
    public uint DisplayCategoryHash { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("displayInBanner")]
    public bool DisplayInBanner { get; init; }

    [JsonPropertyName("progressionHash")]
    public uint? ProgressionHash { get; init; }

    [JsonPropertyName("sortOrder")]
    public Destiny.VendorDisplayCategorySortOrder SortOrder { get; init; }

    [JsonPropertyName("displayStyleHash")]
    public uint? DisplayStyleHash { get; init; }

    [JsonPropertyName("displayStyleIdentifier")]
    public string DisplayStyleIdentifier { get; init; }
}
