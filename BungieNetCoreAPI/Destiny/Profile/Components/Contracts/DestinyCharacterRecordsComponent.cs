using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{
    public class DestinyCharacterRecordsComponent
    {
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRecordDefinition>> FeaturedRecords { get; init; }
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; }
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; }

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
