using NetBungieAPI.Models.Destiny.Definitions.MaterialRequirementSets;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.TalentGrids
{
    public sealed record DestinyNodeActivationRequirement : IDeepEquatable<DestinyNodeActivationRequirement>
    {
        [JsonPropertyName("exclusiveSetRequiredHash")]
        public uint ExclusiveSetRequiredHash { get; init; }
        [JsonPropertyName("gridLevel")]
        public int GridLevel { get; init; }
        [JsonPropertyName("materialRequirementHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>> MaterialRequirements { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>();

        public bool DeepEquals(DestinyNodeActivationRequirement other)
        {
            return other != null &&
                   ExclusiveSetRequiredHash == other.ExclusiveSetRequiredHash &&
                   GridLevel == other.GridLevel &&
                   MaterialRequirements.DeepEqualsReadOnlyCollections(other.MaterialRequirements);
        }
    }
}
