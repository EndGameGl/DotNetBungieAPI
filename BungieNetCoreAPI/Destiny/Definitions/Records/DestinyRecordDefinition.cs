using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Traits;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
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
        public int PresentationNodeType { get; }
        public int RecordValueStyle { get; }
        public RecordRequirements Requirements { get; }
        public int Scope { get; }
        public List<DefinitionHashPointer<DestinyTraitDefinition>> Traits { get; }
        public List<string> TraitIds { get; }

        [JsonConstructor]
        private DestinyRecordDefinition(DestinyDefinitionDisplayProperties displayProperties, RecordCompletionInfo completionInfo, RecordExpirationInfo expirationInfo,
            RecordIntervalInfo intervalInfo, List<uint> objectiveHashes, List<uint> parentNodeHashes, int presentationNodeType, int recordValueStyle, RecordRequirements requirements,
            int scope, RecordStateInfo stateInfo, RecordTitleInfo titleInfo, List<uint> traitHashes, List<string> traitIds,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
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
            TraitIds = traitIds;
            if (objectiveHashes != null)
            {
                Objectives = new List<DefinitionHashPointer<DestinyObjectiveDefinition>>();
                foreach (var objectiveHash in objectiveHashes)
                {
                    Objectives.Add(new DefinitionHashPointer<DestinyObjectiveDefinition>(objectiveHash, "DestinyObjectiveDefinition"));
                }
            }
            if (parentNodeHashes != null)
            {
                ParentNodes = new List<DefinitionHashPointer<DestinyPresentationNodeDefinition>>();
                foreach (var parentNodeHash in parentNodeHashes)
                {
                    ParentNodes.Add(new DefinitionHashPointer<DestinyPresentationNodeDefinition>(parentNodeHash, "DestinyPresentationNodeDefinition"));
                }
            }
            if (traitHashes != null)
            {
                Traits = new List<DefinitionHashPointer<DestinyTraitDefinition>>();
                foreach (var traitHash in traitHashes)
                {
                    Traits.Add(new DefinitionHashPointer<DestinyTraitDefinition>(traitHash, "DestinyTraitDefinition"));
                }
            }
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
