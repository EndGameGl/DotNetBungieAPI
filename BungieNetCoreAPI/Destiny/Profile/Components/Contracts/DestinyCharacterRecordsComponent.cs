using NetBungieAPI.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Destiny.Definitions.Records;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterRecordsComponent
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRecordDefinition>> FeaturedRecords { get; }
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; }

        [JsonConstructor]
        internal DestinyCharacterRecordsComponent(uint[] featuredRecordHashes, Dictionary<uint, DestinyRecordComponent> records, uint recordCategoriesRootNodeHash,
            uint recordSealsRootNodeHash)
        {
            FeaturedRecords = featuredRecordHashes.DefinitionsAsReadOnlyOrEmpty<DestinyRecordDefinition>(DefinitionsEnum.DestinyRecordDefinition);
            Records = records.AsReadOnlyDictionaryOrEmpty();
            RecordCategoriesRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(recordCategoriesRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
            RecordSealsRootNode = new DefinitionHashPointer<DestinyPresentationNodeDefinition>(recordSealsRootNodeHash, DefinitionsEnum.DestinyPresentationNodeDefinition);
        }
    }
}
