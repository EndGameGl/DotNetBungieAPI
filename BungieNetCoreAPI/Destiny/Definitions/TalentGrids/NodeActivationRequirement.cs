using BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class NodeActivationRequirement : IDeepEquatable<NodeActivationRequirement>
    {
        public uint ExclusiveSetRequiredHash { get; }
        public int GridLevel { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>> MaterialRequirements { get; }

        [JsonConstructor]
        internal NodeActivationRequirement(uint exclusiveSetRequiredHash, int gridLevel, uint[] materialRequirementHashes)
        {
            ExclusiveSetRequiredHash = exclusiveSetRequiredHash;
            GridLevel = gridLevel;
            MaterialRequirements = materialRequirementHashes.DefinitionsAsReadOnlyOrEmpty<DestinyMaterialRequirementSetDefinition>(DefinitionsEnum.DestinyMaterialRequirementSetDefinition);
        }

        public bool DeepEquals(NodeActivationRequirement other)
        {
            return other != null &&
                   ExclusiveSetRequiredHash == other.ExclusiveSetRequiredHash &&
                   GridLevel == other.GridLevel &&
                   MaterialRequirements.DeepEqualsReadOnlyCollections(other.MaterialRequirements);
        }
    }
}
