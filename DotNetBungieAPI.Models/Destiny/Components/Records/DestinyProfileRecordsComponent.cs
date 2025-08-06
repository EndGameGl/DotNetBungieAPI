namespace DotNetBungieAPI.Models.Destiny.Components.Records;

public sealed class DestinyProfileRecordsComponent
{
    /// <summary>
    ///     Your 'active' Triumphs score, maintained for backwards compatibility.
    /// </summary>
    [JsonPropertyName("score")]
    public int Score { get; init; }

    /// <summary>
    ///     Your 'active' Triumphs score.
    /// </summary>
    [JsonPropertyName("activeScore")]
    public int ActiveScore { get; init; }

    /// <summary>
    ///     Your 'legacy' Triumphs score.
    /// </summary>
    [JsonPropertyName("legacyScore")]
    public int LegacyScore { get; init; }

    /// <summary>
    ///     Your 'lifetime' Triumphs score.
    /// </summary>
    [JsonPropertyName("lifetimeScore")]
    public int LifetimeScore { get; init; }

    /// <summary>
    ///     If this profile is tracking a record, this is the hash identifier of the record it is tracking.
    /// </summary>
    [JsonPropertyName("trackedRecordHash")]
    public DefinitionHashPointer<Destiny.Definitions.Records.DestinyRecordDefinition>? TrackedRecordHash { get; init; }

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
