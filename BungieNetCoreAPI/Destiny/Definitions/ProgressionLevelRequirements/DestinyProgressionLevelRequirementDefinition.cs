using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.Progressions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.ProgressionLevelRequirements
{
    [DestinyDefinition(name: "DestinyProgressionLevelRequirementDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyProgressionLevelRequirementDefinition : IDestinyDefinition
    {
        public DefinitionHashPointer<DestinyProgressionDefinition> Progression { get; }
        public List<ProgressionLevelRequirementCurveEntry> RequirementCurve { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyProgressionLevelRequirementDefinition(uint progressionHash, List<ProgressionLevelRequirementCurveEntry> requirementCurve,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            Progression = new DefinitionHashPointer<DestinyProgressionDefinition>(progressionHash, DefinitionsEnum.DestinyProgressionDefinition);
            RequirementCurve = requirementCurve;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
