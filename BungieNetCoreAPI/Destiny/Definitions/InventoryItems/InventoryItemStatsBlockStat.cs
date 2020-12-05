using BungieNetCoreAPI.Destiny.Definitions.Stats;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemStatsBlockStat
    {
        public int DisplayMaximum { get; }
        public int Maximum { get; }
        public int Minimum { get; }
        public DefinitionHashPointer<DestinyStatDefinition> Stat { get; }
        public int Value { get; }

        [JsonConstructor]
        private InventoryItemStatsBlockStat(int displayMaximum, int maximum, int minimum, uint statHash, int value)
        {
            DisplayMaximum = displayMaximum;
            Maximum = maximum;
            Minimum = minimum;
            Stat = new DefinitionHashPointer<DestinyStatDefinition>(statHash, "DestinyStatDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            Value = value;
        }
    }
}
