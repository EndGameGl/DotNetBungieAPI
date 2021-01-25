using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Lores;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    [DestinyDefinition(name: "DestinyRecordDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyRecordDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public RecordCompletionInfo CompletionInfo { get; }
        public RecordExpirationInfo ExpirationInfo { get; }
        public RecordIntervalInfo IntervalInfo { get; }
        public RecordStateInfo StateInfo { get; }
        public RecordTitleInfo TitleInfo { get; }
        public List<DefinitionHashPointer<DestinyObjectiveDefinition>> Objectives { get; }
        public List<DefinitionHashPointer<DestinyPresentationNodeDefinition>> ParentNodes { get; }
        public PresentationNodeType PresentationNodeTypeEnumValue { get; }
        public RecordValueStyle RecordValueStyleEnumValue { get; }
        public RecordRequirements Requirements { get; }
        public List<RecordRewardItem> RewardItems { get; }
        public Scope ScopeEnumValue { get; }
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public List<string> TraitIds { get; }
        public DefinitionHashPointer<DestinyLoreDefinition> Lore { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyRecordDefinition(DestinyDefinitionDisplayProperties displayProperties, RecordCompletionInfo completionInfo, RecordExpirationInfo expirationInfo,
            RecordIntervalInfo intervalInfo, List<uint> objectiveHashes, List<uint> parentNodeHashes, PresentationNodeType presentationNodeType, 
            RecordValueStyle recordValueStyle, RecordRequirements requirements, Scope scope, RecordStateInfo stateInfo, RecordTitleInfo titleInfo, 
            List<uint> traitHashes, List<string> traitIds, List<RecordRewardItem> rewardItems, uint loreHash, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            CompletionInfo = completionInfo;
            ExpirationInfo = expirationInfo;
            IntervalInfo = intervalInfo;
            PresentationNodeTypeEnumValue = presentationNodeType;
            RecordValueStyleEnumValue = recordValueStyle;
            Requirements = requirements;
            ScopeEnumValue = scope;
            StateInfo = stateInfo;
            TitleInfo = titleInfo;
            TraitIds = traitIds;
            if (objectiveHashes != null)
            {
                Objectives = new List<DefinitionHashPointer<DestinyObjectiveDefinition>>();
                foreach (var objectiveHash in objectiveHashes)
                {
                    Objectives.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, DefinitionsEnum.DestinyObjectiveDefinition));
                }
            }
            if (parentNodeHashes != null)
            {
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition));
                }
            }
            if (traitHashes != null)
            {
                Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, DefinitionsEnum.DestinyTraitDefinition));
                }
            }
            RewardItems = rewardItems;
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, DefinitionsEnum.DestinyLoreDefinition);
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
