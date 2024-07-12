namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Records;

public class DestinyCharacterRecordsComponent
{
    [Destiny2DefinitionList<Destiny.Definitions.Records.DestinyRecordDefinition>("Destiny.Definitions.Records.DestinyRecordDefinition")]
    [JsonPropertyName("featuredRecordHashes")]
    public List<uint> FeaturedRecordHashes { get; set; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent> Records { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public uint? RecordCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("recordSealsRootNodeHash")]
    public uint? RecordSealsRootNodeHash { get; set; }
}
