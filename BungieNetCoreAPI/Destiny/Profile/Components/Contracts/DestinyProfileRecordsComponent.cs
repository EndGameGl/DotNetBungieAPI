using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Destiny.Definitions.Records;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyProfileRecordsComponent
    {
        public int Score { get; init; }
        public int ActiveScore { get; init; }
        public int LegacyScore { get; init; }
        public int LifetimeScore { get; init; }
        public DefinitionHashPointer<DestinyRecordDefinition> TrackedRecord { get; init; }
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; }

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
