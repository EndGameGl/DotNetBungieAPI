using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Records;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyProfileRecordsComponent
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
    public DefinitionHashPointer<DestinyRecordDefinition> TrackedRecord { get; init; } =
        DefinitionHashPointer<DestinyRecordDefinition>.Empty;

    [JsonPropertyName("records")]
    public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; } =
        ReadOnlyDictionaries<uint, DestinyRecordComponent>.Empty;

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph categories.
    /// </summary>
    [JsonPropertyName("recordCategoriesRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    /// <summary>
    ///     The hash for the root presentation node definition of Triumph Seals.
    /// </summary>
    [JsonPropertyName("recordSealsRootNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
}
