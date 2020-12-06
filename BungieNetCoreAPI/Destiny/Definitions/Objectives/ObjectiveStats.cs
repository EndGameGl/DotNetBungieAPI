using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Objectives
{
    public class ObjectiveStats
    {
        public ObjectiveStat Stat { get; }
        public int Style { get; }

        [JsonConstructor]
        private ObjectiveStats(ObjectiveStat stat, int style)
        {
            Stat = stat;
            Style = style;
        }
    }
}
