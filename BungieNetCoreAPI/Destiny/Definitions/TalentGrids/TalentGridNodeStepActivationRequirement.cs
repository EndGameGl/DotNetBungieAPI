using BungieNetCoreAPI.Destiny.Definitions.MaterialRequirementSets;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.TalentGrids
{
    public class TalentGridNodeStepActivationRequirement
    {
        public uint ExclusiveSetRequiredHash { get; }
        public int GridLevel { get; }
        public List<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>> MaterialRequirements { get; }

        [JsonConstructor]
        private TalentGridNodeStepActivationRequirement(uint exclusiveSetRequiredHash, int gridLevel, List<uint> materialRequirementHashes)
        {
            ExclusiveSetRequiredHash = exclusiveSetRequiredHash;
            GridLevel = gridLevel;
            MaterialRequirements = new List<DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>>();
            if (materialRequirementHashes != null)
            {
                foreach (var materialRequirementHash in materialRequirementHashes)
                {
                    MaterialRequirements.Add(new DefinitionHashPointer<DestinyMaterialRequirementSetDefinition>(materialRequirementHash, "DestinyMaterialRequirementSetDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext));
                }
            }
        }
    }
}
