﻿using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.Lores;
using NetBungieAPI.Models.Destiny.Definitions.Objectives;
using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Traits;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Records
{
    [DestinyDefinition(DefinitionsEnum.DestinyRecordDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public sealed record DestinyRecordDefinition : IDestinyDefinition, IDeepEquatable<DestinyRecordDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("scope")]
        public DestinyScope Scope { get; init; }
        [JsonPropertyName("presentationInfo")]
        public DestinyPresentationChildBlock PresentationInfo { get; init; }
        [JsonPropertyName("loreHash")]
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; init; } = DefinitionHashPointer<DestinyLoreDefinition>.Empty;
        [JsonPropertyName("objectiveHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>>();
        [JsonPropertyName("recordValueStyle")]
        public DestinyRecordValueStyle RecordValueStyle { get; init; }
        [JsonPropertyName("forTitleGilding")]
        public bool ForTitleGilding { get; init; }
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
        [JsonPropertyName("intervalInfo")]
        public DestinyRecordIntervalBlock IntervalInfo { get; init; }
        [JsonPropertyName("rewardItems")]
        public ReadOnlyCollection<DestinyItemQuantity> RewardItems { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemQuantity>();
        [JsonPropertyName("presentationNodeType")]
        public DestinyPresentationNodeType PresentationNodeType { get; init; }
        [JsonPropertyName("traitIds")]
        public ReadOnlyCollection<string> TraitIds { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        [JsonPropertyName("traitHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>>();
        [JsonPropertyName("parentNodeHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
        [JsonPropertyName("blacklisted")]
        public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")]
        public uint Hash { get; init; }
        [JsonPropertyName("index")]
        public int Index { get; init; }
        [JsonPropertyName("redacted")]
        public bool Redacted { get; init; }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
        public bool DeepEquals(DestinyRecordDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   CompletionInfo.DeepEquals(other.CompletionInfo) &&
                   ExpirationInfo.DeepEquals(other.ExpirationInfo) &&
                   IntervalInfo.DeepEquals(other.IntervalInfo) &&
                   StateInfo.DeepEquals(other.StateInfo) &&
                   TitleInfo.DeepEquals(other.TitleInfo) &&
                   Objectives.DeepEqualsReadOnlyCollections(other.Objectives) &&
                   ParentNodes.DeepEqualsReadOnlyCollections(other.ParentNodes) &&
                   PresentationNodeType == other.PresentationNodeType &&
                   RecordValueStyle == other.RecordValueStyle &&
                   Requirements.DeepEquals(other.Requirements) &&
                   RewardItems.DeepEqualsReadOnlyCollections(other.RewardItems) &&
                   Scope == other.Scope &&
                   Traits.DeepEqualsReadOnlyCollections(other.Traits) &&
                   TraitIds.DeepEqualsReadOnlySimpleCollection(other.TraitIds) &&
                   Lore.DeepEquals(other.Lore) &&
                   PresentationInfo.DeepEquals(other.PresentationInfo) &&
                   ForTitleGilding == other.ForTitleGilding &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            if (IntervalInfo != null)
            {
                foreach (var objective in IntervalInfo.IntervalObjectives)
                {
                    objective.IntervalObjective.TryMapValue();
                }
                foreach (var reward in IntervalInfo.IntervalRewards)
                {
                    foreach (var item in reward.IntervalRewardItems)
                    {
                        item.Item.TryMapValue();
                    }
                }
            }
            if (TitleInfo != null)
            {
                TitleInfo.GildingTrackingRecord.TryMapValue();
                foreach (var gender in TitleInfo.TitlesByGenderHash.Keys)
                {
                    gender.TryMapValue();
                }
            }
            foreach (var objective in Objectives)
            {
                objective.TryMapValue();
            }
            foreach (var node in ParentNodes)
            {
                node.TryMapValue();
            }
            foreach (var item in RewardItems)
            {
                item.Item.TryMapValue();
            }
            foreach (var trait in Traits)
            {
                trait.TryMapValue();
            }
            Lore.TryMapValue();
            if (PresentationInfo != null)
            {
                foreach (var node in PresentationInfo.ParentPresentationNodes)
                {
                    node.TryMapValue();
                }
            }
        }
    }
}