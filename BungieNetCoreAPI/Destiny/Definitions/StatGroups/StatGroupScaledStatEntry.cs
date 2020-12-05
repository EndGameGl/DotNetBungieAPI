using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.StatGroups
{
    public class StatGroupScaledStatEntry
    {
        public bool DisplayAsNumeric { get; }
        public List<StatGroupInterpolationEntry> DisplayInterpolation { get; }
        public int MaximumValue { get; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }

        [JsonConstructor]
        private StatGroupScaledStatEntry(bool displayAsNumeric, List<StatGroupInterpolationEntry> displayInterpolation, int maximumValue, uint statHash)
        {
            DisplayAsNumeric = displayAsNumeric;
            DisplayInterpolation = displayInterpolation;
            MaximumValue = maximumValue;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, "DestinyStatDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
        }
    }
}
