using NetBungieAPI.Models.Destiny.Definitions.Common;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record TalentGridNodeCategory : IDeepEquatable<TalentGridNodeCategory>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        [JsonPropertyName("identifier")]
        public string Identifier { get; init; }
        [JsonPropertyName("isLoreDriven")]
        public bool IsLoreDriven { get; init; }
        [JsonPropertyName("nodeHashes")]
        public ReadOnlyCollection<uint> NodeHashes { get; init; } = Defaults.EmptyReadOnlyCollection<uint>();

        public bool DeepEquals(TalentGridNodeCategory other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Identifier == other.Identifier &&
                   IsLoreDriven == other.IsLoreDriven &&
                   NodeHashes.DeepEqualsReadOnlySimpleCollection(other.NodeHashes);
        }
    }
}
