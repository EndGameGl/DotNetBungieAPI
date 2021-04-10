using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterRecordsComponent
    {
        [JsonPropertyName("featuredRecordHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRecordDefinition>> FeaturedRecords { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyRecordDefinition>>();
        [JsonPropertyName("records")]
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyRecordComponent>();
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
        [JsonPropertyName("recordSealsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}
