namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

public class DestinyRecordDefinition : IDeepEquatable<DestinyRecordDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     Indicates whether this Record's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; set; }

    [JsonPropertyName("loreHash")]
    public uint? LoreHash { get; set; }

    [JsonPropertyName("objectiveHashes")]
    public List<uint> ObjectiveHashes { get; set; }

    [JsonPropertyName("recordValueStyle")]
    public Destiny.DestinyRecordValueStyle RecordValueStyle { get; set; }

    [JsonPropertyName("forTitleGilding")]
    public bool ForTitleGilding { get; set; }

    [JsonPropertyName("titleInfo")]
    public Destiny.Definitions.Records.DestinyRecordTitleBlock TitleInfo { get; set; }

    [JsonPropertyName("completionInfo")]
    public Destiny.Definitions.Records.DestinyRecordCompletionBlock CompletionInfo { get; set; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Records.SchemaRecordStateBlock StateInfo { get; set; }

    [JsonPropertyName("requirements")]
    public Destiny.Definitions.Presentation.DestinyPresentationNodeRequirementsBlock Requirements { get; set; }

    [JsonPropertyName("expirationInfo")]
    public Destiny.Definitions.Records.DestinyRecordExpirationBlock ExpirationInfo { get; set; }

    /// <summary>
    ///     Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval
    /// </summary>
    [JsonPropertyName("intervalInfo")]
    public Destiny.Definitions.Records.DestinyRecordIntervalBlock IntervalInfo { get; set; }

    /// <summary>
    ///     If there is any publicly available information about rewards earned for achieving this record, this is the list of those items.
    /// <para />
    ///      However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public List<Destiny.DestinyItemQuantity> RewardItems { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; set; }

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

    public bool DeepEquals(DestinyRecordDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Scope == other.Scope &&
               (PresentationInfo is not null ? PresentationInfo.DeepEquals(other.PresentationInfo) : other.PresentationInfo is null) &&
               LoreHash == other.LoreHash &&
               ObjectiveHashes.DeepEqualsListNaive(other.ObjectiveHashes) &&
               RecordValueStyle == other.RecordValueStyle &&
               ForTitleGilding == other.ForTitleGilding &&
               (TitleInfo is not null ? TitleInfo.DeepEquals(other.TitleInfo) : other.TitleInfo is null) &&
               (CompletionInfo is not null ? CompletionInfo.DeepEquals(other.CompletionInfo) : other.CompletionInfo is null) &&
               (StateInfo is not null ? StateInfo.DeepEquals(other.StateInfo) : other.StateInfo is null) &&
               (Requirements is not null ? Requirements.DeepEquals(other.Requirements) : other.Requirements is null) &&
               (ExpirationInfo is not null ? ExpirationInfo.DeepEquals(other.ExpirationInfo) : other.ExpirationInfo is null) &&
               (IntervalInfo is not null ? IntervalInfo.DeepEquals(other.IntervalInfo) : other.IntervalInfo is null) &&
               RewardItems.DeepEqualsList(other.RewardItems) &&
               PresentationNodeType == other.PresentationNodeType &&
               TraitIds.DeepEqualsListNaive(other.TraitIds) &&
               TraitHashes.DeepEqualsListNaive(other.TraitHashes) &&
               ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}