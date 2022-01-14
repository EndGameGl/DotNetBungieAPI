namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public sealed class DestinyCharacterRecordsComponent
{

    [JsonPropertyName("featuredRecordHashes")]
    public List<uint> FeaturedRecordHashes { get; init; } // DestinyRecordDefinition

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint RecordCategoriesRootNodeHash { get; init; } // DestinyPresentationNodeDefinition

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint RecordSealsRootNodeHash { get; init; } // DestinyPresentationNodeDefinition
}
