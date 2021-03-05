using BungieNetCoreAPI.Destiny.Definitions.PresentationNodes;
using BungieNetCoreAPI.Destiny.Definitions.Records;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileRecordsComponent
    {
        public int Score { get; }
        public int ActiveScore { get; }
        public int LegacyScore { get; }
        public int LifetimeScore { get; }
        public DefinitionHashPointer<DestinyRecordDefinition> TrackedRecord { get; }
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; }

        [JsonConstructor]
        internal DestinyProfileRecordsComponent(int score, int activeScore, int legacyScore, int lifetimeScore, uint? trackedRecordHash,
            Dictionary<uint, DestinyRecordComponent> records, uint recordCategoriesRootNodeHash, uint recordSealsRootNodeHash)
        {
            Score = score;
            ActiveScore = activeScore;
            LegacyScore = legacyScore;
            LifetimeScore = lifetimeScore;
            TrackedRecord = new DefinitionHashPointer<DestinyRecordDefinition>(trackedRecordHash, DefinitionsEnum.DestinyRecordDefinition);
            Records = records.AsReadOnlyDictionaryOrEmpty();
            RecordCategoriesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(recordCategoriesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            RecordSealsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(recordSealsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
