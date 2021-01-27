using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.PowerCaps
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyPowerCapDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyPowerCapDefinition : IDestinyDefinition
    {
        public int PowerCap { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyPowerCapDefinition(int powerCap, bool blacklisted, uint hash, int index, bool redacted)
        {
            PowerCap = powerCap;
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
