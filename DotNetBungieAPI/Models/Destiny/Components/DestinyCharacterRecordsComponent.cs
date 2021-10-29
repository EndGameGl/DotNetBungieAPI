using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using DotNetBungieAPI.Defaults;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Records;

namespace DotNetBungieAPI.Models.Destiny.Components
{
    public sealed record DestinyCharacterRecordsComponent
    {
        [JsonPropertyName("featuredRecordHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyRecordDefinition>> FeaturedRecords { get; init; } =
            ReadOnlyCollections<DefinitionHashPointer<DestinyRecordDefinition>>.Empty;

        [JsonPropertyName("records")]
        public ReadOnlyDictionary<uint, DestinyRecordComponent> Records { get; init; } =
            ReadOnlyDictionaries<uint, DestinyRecordComponent>.Empty;

        /// <summary>
        ///     The hash for the root presentation node definition of Triumph categories.
        /// </summary>
        [JsonPropertyName("recordCategoriesRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordCategoriesRootNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

        /// <summary>
        ///     The hash for the root presentation node definition of Triumph Seals.
        /// </summary>
        [JsonPropertyName("recordSealsRootNodeHash")]
        public DefinitionHashPointer<DestinyPresentationNodeDefinition> RecordSealsRootNode { get; init; } =
            DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;
    }
}