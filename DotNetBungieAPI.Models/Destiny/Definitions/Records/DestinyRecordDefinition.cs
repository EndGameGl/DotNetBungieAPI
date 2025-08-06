namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

[DestinyDefinition(DefinitionsEnum.DestinyRecordDefinition)]
public sealed class DestinyRecordDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyRecordDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     Indicates whether this Record's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock? PresentationInfo { get; init; }

    [JsonPropertyName("loreHash")]
    public DefinitionHashPointer<Destiny.Definitions.Lore.DestinyLoreDefinition>? LoreHash { get; init; }

    [JsonPropertyName("objectiveHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyObjectiveDefinition>[]? ObjectiveHashes { get; init; }

    [JsonPropertyName("recordValueStyle")]
    public Destiny.DestinyRecordValueStyle RecordValueStyle { get; init; }

    [JsonPropertyName("forTitleGilding")]
    public bool ForTitleGilding { get; init; }

    /// <summary>
    ///     A hint to show a large icon for a reward
    /// </summary>
    [JsonPropertyName("shouldShowLargeIcons")]
    public bool ShouldShowLargeIcons { get; init; }

    [JsonPropertyName("titleInfo")]
    public Destiny.Definitions.Records.DestinyRecordTitleBlock? TitleInfo { get; init; }

    [JsonPropertyName("completionInfo")]
    public Destiny.Definitions.Records.DestinyRecordCompletionBlock? CompletionInfo { get; init; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Records.SchemaRecordStateBlock? StateInfo { get; init; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock? Requirements { get; init; }

    [JsonPropertyName("expirationInfo")]
    public Destiny.Definitions.Records.DestinyRecordExpirationBlock? ExpirationInfo { get; init; }

    /// <summary>
    ///     Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval
    /// </summary>
    [JsonPropertyName("intervalInfo")]
    public Destiny.Definitions.Records.DestinyRecordIntervalBlock? IntervalInfo { get; init; }

    /// <summary>
    ///     If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
    /// <para />
    ///      However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public Destiny.DestinyItemQuantity[]? RewardItems { get; init; }

    /// <summary>
    ///     A display name for the type of record this is (Triumphs, Lore, Medals, Seasonal Challenge, etc.).
    /// </summary>
    [JsonPropertyName("recordTypeName")]
    public string RecordTypeName { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public string[]? TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Traits.DestinyTraitDefinition>[]? TraitHashes { get; init; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>[]? ParentNodeHashes { get; init; }

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
