namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyRecordsComponent : IDeepEquatable<DestinyRecordsComponent>
{
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

    public bool DeepEquals(DestinyRecordsComponent? other)
    {
        return other is not null &&
               Records.DeepEqualsDictionary(other.Records) &&
               RecordCategoriesRootNodeHash == other.RecordCategoriesRootNodeHash &&
               RecordSealsRootNodeHash == other.RecordSealsRootNodeHash;
    }
}