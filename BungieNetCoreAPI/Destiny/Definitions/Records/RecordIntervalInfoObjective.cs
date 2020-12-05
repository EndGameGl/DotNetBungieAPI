using BungieNetCoreAPI.Destiny.Definitions.Objectives;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Records
{
    public class RecordIntervalInfoObjective
    {
        public DefinitionHashPointer<DestinyObjectiveDefinition> IntervalObjective { get; }
        public int IntervalScoreValue { get; }

        [JsonConstructor]
        private RecordIntervalInfoObjective(uint intervalObjectiveHash, int intervalScoreValue)
        {
            IntervalObjective = new DefinitionHashPointer<DestinyObjectiveDefinition>(intervalObjectiveHash, "DestinyObjectiveDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            IntervalScoreValue = intervalScoreValue;
        }
    }
}
