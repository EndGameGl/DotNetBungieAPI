namespace DotNetBungieAPI.Models.Destiny.Components.Records;

public sealed class DestinyCharacterRecordsComponent
{
    [JsonPropertyName("featuredRecordHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Records.DestinyRecordDefinition>[]? FeaturedRecordHashes { get; init; }

    [JsonPropertyName("records")]
    public Dictionary<uint, Destiny.Components.Records.DestinyRecordComponent>? Records { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> RecordCategoriesRootNodeHash { get; init; }

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> RecordSealsRootNodeHash { get; init; }
}
