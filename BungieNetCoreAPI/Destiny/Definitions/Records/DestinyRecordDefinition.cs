using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Lores;
using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    [DestinyDefinition("DestinyRecordDefinition")]
    public class DestinyRecordDefinition : DestinyDefinition
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

        [JsonConstructor]
        private DestinyRecordDefinition(DestinyDefinitionDisplayProperties displayProperties, RecordCompletionInfo completionInfo, RecordExpirationInfo expirationInfo,
            RecordIntervalInfo intervalInfo, List<uint> objectiveHashes, List<uint> parentNodeHashes, PresentationNodeType presentationNodeType, 
            RecordValueStyle recordValueStyle, RecordRequirements requirements, Scope scope, RecordStateInfo stateInfo, RecordTitleInfo titleInfo, 
            List<uint> traitHashes, List<string> traitIds, List<RecordRewardItem> rewardItems, uint loreHash, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
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
                    Objectives.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, "DestinyObjectiveDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext));
                }
            }
            if (parentNodeHashes != null)
            {
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, "DestinyPresentationNodeDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext));
                }
            }
            if (traitHashes != null)
            {
                Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, "DestinyTraitDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext));
                }
            }
            RewardItems = rewardItems;
            Lore = new DefinitionHashPointer<DestinyLoreDefinition>(loreHash, "DestinyLoreDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
