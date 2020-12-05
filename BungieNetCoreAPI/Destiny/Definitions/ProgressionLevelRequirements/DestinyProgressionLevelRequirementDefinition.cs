using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements
{
    [DestinyDefinition("DestinyProgressionLevelRequirementDefinition")]
    public class DestinyProgressionLevelRequirementDefinition : DestinyDefinition
    {
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public List<ProgressionLevelRequirementCurveEntry> RequirementCurve { get; }
        [JsonConstructor]
        private DestinyProgressionLevelRequirementDefinition(uint progressionHash, List<ProgressionLevelRequirementCurveEntry> requirementCurve,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, "DestinyProgressionDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            RequirementCurve = requirementCurve;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
