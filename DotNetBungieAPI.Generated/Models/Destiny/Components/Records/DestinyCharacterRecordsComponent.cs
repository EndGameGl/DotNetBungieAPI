using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public sealed class DestinyCharacterRecordsComponent
{

    [JsonPropertyName("featuredRecordHashes")]
    public List<uint> FeaturedRecordHashes { get; init; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; init; }

    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; init; }

    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; init; }
}
