using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Lores;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    [DestinyDefinition(DefinitionsEnum.DestinyRecordDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyRecordDefinition : IDestinyDefinition, IDeepEquatable<DestinyRecordDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public RecordCompletionInfo CompletionInfo { get; }
        public RecordExpirationInfo ExpirationInfo { get; }
        public RecordIntervalInfo IntervalInfo { get; }
        public RecordStateInfo StateInfo { get; }
        public RecordTitleInfo TitleInfo { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeType { get; }
        public RecordValueStyle RecordValueStyle { get; }
        public RecordRequirements Requirements { get; }
        public ReadOnlyCollection<DestinyItemQuantity> RewardItems { get; }
        public Scope Scope { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public ReadOnlyCollection<string> TraitIds { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public RecordPresentationInfo PresentationInfo { get; }
        public bool ForTitleGilding { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyRecordDefinition(DestinyDefinitionDisplayProperties displayProperties, RecordCompletionInfo completionInfo, RecordExpirationInfo expirationInfo,
            RecordIntervalInfo intervalInfo, uint[] objectiveHashes, uint[] parentNodeHashes, PresentationNodeType presentationNodeType, 
            RecordValueStyle recordValueStyle, RecordRequirements requirements, Scope scope, RecordStateInfo stateInfo, RecordTitleInfo titleInfo, 
            uint[] traitHashes, string[] traitIds, DestinyItemQuantity[] rewardItems, uint loreHash, RecordPresentationInfo presentationInfo, bool forTitleGilding,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            CompletionInfo = completionInfo;
            ExpirationInfo = expirationInfo;
            IntervalInfo = intervalInfo;
            PresentationNodeType = presentationNodeType;
            RecordValueStyle = recordValueStyle;
            Requirements = requirements;
            Scope = scope;
            StateInfo = stateInfo;
            TitleInfo = titleInfo;
            TraitIds = traitIds.AsReadOnlyOrEmpty();
            Objectives = objectiveHashes.DefinitionsAsReadOnlyOrEmpty<DestinyObjectiveDefinition>(DefinitionsEnum.DestinyObjectiveDefinition);
            ParentNodes = parentNodeHashes.DefinitionsAsReadOnlyOrEmpty<DestinyPresentationNodeDefinition>(DefinitionsEnum.DestinyPresentationNodeDefinition);
            Traits = traitHashes.DefinitionsAsReadOnlyOrEmpty<DestinyTraitDefinition>(DefinitionsEnum.DestinyTraitDefinition);
            RewardItems = rewardItems.AsReadOnlyOrEmpty();
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, DefinitionsEnum.DestinyLoreDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
            PresentationInfo = presentationInfo;
            ForTitleGilding = forTitleGilding;
        }

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
