using NetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using NetBungieAPI.Models.Destiny.Definitions.Records;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyProfileRecordsComponent
    {
        [JsonPropertyName("score")]
        public int Score { get; init; }
        [JsonPropertyName("activeScore")]
        public int ActiveScore { get; init; }
        [JsonPropertyName("legacyScore")]
        public int LegacyScore { get; init; }
        [JsonPropertyName("lifetimeScore")]
        public int LifetimeScore { get; init; }
        [JsonPropertyName("trackedRecordHash")]
        public DefinitionHashPointer<DestinyRecordDefinition> TrackedRecord { get; init; } = DefinitionHashPointer<DestinyRecordDefinition>.Empty;
        [JsonPropertyName("records")]
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; } = Defaults.EmptyReadOnlyDictionary<uint, DestinyRecordComponent>();
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
        [JsonPropertyName("recordSealsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; } = DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}
