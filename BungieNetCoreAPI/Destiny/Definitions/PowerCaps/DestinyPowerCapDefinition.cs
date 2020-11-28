using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PowerCaps
{
    public class DestinyPowerCapDefinition : DestinyDefinition
    {
        public int PowerCap { get; }
        [JsonConstructor]
        private DestinyPowerCapDefinition(int powerCap, bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            PowerCap = powerCap;
        }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
