namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyCharacterRecordsComponent : IDeepEquatable<DestinyCharacterRecordsComponent>
{
    [JsonPropertyName("featuredRecordHashes")]
    public List<uint> FeaturedRecordHashes { get; set; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; set; }

    public bool DeepEquals(DestinyCharacterRecordsComponent? other)
    {
        return other is not null &&
               FeaturedRecordHashes.DeepEqualsListNaive(other.FeaturedRecordHashes) &&
               Records.DeepEqualsDictionary(other.Records) &&
               RecordCategoriesRootNodeHash == other.RecordCategoriesRootNodeHash &&
               RecordSealsRootNodeHash == other.RecordSealsRootNodeHash;
    }
}