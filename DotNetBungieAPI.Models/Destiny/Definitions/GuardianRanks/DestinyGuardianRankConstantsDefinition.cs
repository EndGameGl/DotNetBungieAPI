namespace DotNetBungieAPI.Models.Destiny.Definitions.GuardianRanks;

[DestinyDefinition(DefinitionsEnum.DestinyGuardianRankConstantsDefinition)]
public sealed class DestinyGuardianRankConstantsDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyGuardianRankConstantsDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("rankCount")]
    public int RankCount { get; init; }

    [JsonPropertyName("guardianRankHashes")]
    public DefinitionHashPointer<Destiny.Definitions.GuardianRanks.DestinyGuardianRankDefinition>[]? GuardianRankHashes { get; init; }

    [JsonPropertyName("rootNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> RootNodeHash { get; init; }

    [JsonPropertyName("iconBackgrounds")]
    public Destiny.Definitions.GuardianRanks.DestinyGuardianRankIconBackgroundsDefinition? IconBackgrounds { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
