namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     Indicates whether this Record's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock? PresentationInfo { get; set; }

    [Destiny2Definition<Destiny.Definitions.Lore.DestinyLoreDefinition>("Destiny.Definitions.Lore.DestinyLoreDefinition")]
    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyObjectiveDefinition>("Destiny.Definitions.DestinyObjectiveDefinition")]
    [JsonPropertyName("objectiveHashes")]
    public uint[]? ObjectiveHashes { get; set; }

    [JsonPropertyName("recordValueStyle")]
    public Destiny.DestinyRecordValueStyle RecordValueStyle { get; set; }

    [JsonPropertyName("forTitleGilding")]
    public bool ForTitleGilding { get; set; }

    /// <summary>
    ///     A hint to show a large icon for a reward
    /// </summary>
    [JsonPropertyName("shouldShowLargeIcons")]
    public bool ShouldShowLargeIcons { get; set; }

    [JsonPropertyName("titleInfo")]
    public Destiny.Definitions.Records.DestinyRecordTitleBlock? TitleInfo { get; set; }

    [JsonPropertyName("completionInfo")]
    public Destiny.Definitions.Records.DestinyRecordCompletionBlock? CompletionInfo { get; set; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Records.SchemaRecordStateBlock? StateInfo { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock? Requirements { get; set; }

    [JsonPropertyName("expirationInfo")]
    public Destiny.Definitions.Records.DestinyRecordExpirationBlock? ExpirationInfo { get; set; }

    /// <summary>
    ///     Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval
    /// </summary>
    [JsonPropertyName("intervalInfo")]
    public Destiny.Definitions.Records.DestinyRecordIntervalBlock? IntervalInfo { get; set; }

    /// <summary>
    ///     If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
    /// <para />
    ///      However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public Destiny.DestinyItemQuantity[]? RewardItems { get; set; }

    /// <summary>
    ///     A display name for the type of record this is (Triumphs, Lore, Medals, Seasonal Challenge, etc.).
    /// </summary>
    [JsonPropertyName("recordTypeName")]
    public string RecordTypeName { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public string[]? TraitIds { get; set; }

    [Destiny2Definition<Destiny.Definitions.Traits.DestinyTraitDefinition>("Destiny.Definitions.Traits.DestinyTraitDefinition")]
    [JsonPropertyName("traitHashes")]
    public uint[]? TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition>("Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition")]
    [JsonPropertyName("parentNodeHashes")]
    public uint[]? ParentNodeHashes { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }
}
