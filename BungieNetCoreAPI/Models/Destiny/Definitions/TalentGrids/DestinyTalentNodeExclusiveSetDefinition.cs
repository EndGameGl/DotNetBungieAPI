using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyTalentNodeExclusiveSetDefinition : IDeepEquatable<DestinyTalentNodeExclusiveSetDefinition>
    {
        [JsonPropertyName("nodeIndexes")]
        public ReadOnlyCollection<int> NodeIndexes { get; init; } = Defaults.EmptyReadOnlyCollection<int>();

        public bool DeepEquals(DestinyTalentNodeExclusiveSetDefinition other)
        {
            return other != null &&
                   NodeIndexes.DeepEqualsReadOnlySimpleCollection(other.NodeIndexes);
        }
    }
}
