using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Lore;
using DotNetBungieAPI.Models.Destiny.Definitions.Objectives;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Traits;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Records;

[DestinyDefinition(DefinitionsEnum.DestinyRecordDefinition)]
public sealed record DestinyRecordDefinition
    : IDestinyDefinition,
        IDisplayProperties,
        IDeepEquatable<DestinyRecordDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     Indicates whether this Record's state is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public DestinyScope Scope { get; init; }

    [JsonPropertyName("presentationInfo")]
    public DestinyPresentationChildBlock PresentationInfo { get; init; }

    [JsonPropertyName("loreHash")]
    public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } =
        DefinitionHashPointer<DestinyLoreDefinition>.Empty;

    [JsonPropertyName("objectiveHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyObjectiveDefinition>
    > Objectives { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyObjectiveDefinition>>.Empty;

    [JsonPropertyName("recordValueStyle")]
    public DestinyRecordValueStyle RecordValueStyle { get; init; }

    [JsonPropertyName("forTitleGilding")]
    public bool ForTitleGilding { get; init; }

    [JsonPropertyName("shouldShowLargeIcons")]
    public bool ShouldShowLargeIcons { get; init; }

    [JsonPropertyName("titleInfo")]
    public DestinyRecordTitleBlock TitleInfo { get; init; }

    [JsonPropertyName("completionInfo")]
    public DestinyRecordCompletionBlock CompletionInfo { get; init; }

    [JsonPropertyName("stateInfo")]
    public SchemaRecordStateBlock StateInfo { get; init; }

    [JsonPropertyName("requirements")]
    public DestinyPresentationNodeRequirementsBlock Requirements { get; init; }

    [JsonPropertyName("expirationInfo")]
    public DestinyRecordExpirationBlock ExpirationInfo { get; init; }

    /// <summary>
    ///     Some records have multiple 'interval' objectives, and the record may be claimed at each completed interval
    /// </summary>
    [JsonPropertyName("intervalInfo")]
    public DestinyRecordIntervalBlock IntervalInfo { get; init; }

    /// <summary>
    ///     If there is any publicly available information about rewards earned for achieving this record, this is the list of
    ///     those items.
    ///     <para />
    ///     However, note that some records intentionally have "hidden" rewards. These will not be returned in this list.
    /// </summary>
    [JsonPropertyName("rewardItems")]
    public ReadOnlyCollection<DestinyItemQuantity> RewardItems { get; init; } =
        ReadOnlyCollections<DestinyItemQuantity>.Empty;

    [JsonPropertyName("recordTypeName")]
    public string RecordTypeName { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public ReadOnlyCollection<string> TraitIds { get; init; } = ReadOnlyCollections<string>.Empty;

    [JsonPropertyName("traitHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyTraitDefinition>>.Empty;

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under
    ///     multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyPresentationNodeDefinition>
    > ParentNodes { get; init; } =
        ReadOnlyCollections<DefinitionHashPointer<DestinyPresentationNodeDefinition>>.Empty;

    public bool DeepEquals(DestinyRecordDefinition other)
    {
        return other != null
            && DisplayProperties.DeepEquals(other.DisplayProperties)
            && CompletionInfo.DeepEquals(other.CompletionInfo)
            && ExpirationInfo.DeepEquals(other.ExpirationInfo)
            && IntervalInfo.DeepEquals(other.IntervalInfo)
            && StateInfo.DeepEquals(other.StateInfo)
            && TitleInfo.DeepEquals(other.TitleInfo)
            && Objectives.DeepEqualsReadOnlyCollections(other.Objectives)
            && ParentNodes.DeepEqualsReadOnlyCollections(other.ParentNodes)
            && PresentationNodeType == other.PresentationNodeType
            && RecordValueStyle == other.RecordValueStyle
            && Requirements.DeepEquals(other.Requirements)
            && RewardItems.DeepEqualsReadOnlyCollections(other.RewardItems)
            && RecordTypeName == other.RecordTypeName
            && Scope == other.Scope
            && Traits.DeepEqualsReadOnlyCollections(other.Traits)
            && TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds)
            && Lore.DeepEquals(other.Lore)
            && PresentationInfo.DeepEquals(other.PresentationInfo)
            && ForTitleGilding == other.ForTitleGilding
            && Blacklisted == other.Blacklisted
            && Hash == other.Hash
            && Index == other.Index
            && Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyRecordDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
