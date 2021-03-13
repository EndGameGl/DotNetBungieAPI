using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.PowerCaps
{
    /// <summary>
    /// Defines a 'power cap' (limit) for gear items, based on the rarity tier and season of release.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPowerCapDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyPowerCapDefinition : IDestinyDefinition, IDeepEquatable<DestinyPowerCapDefinition>
    {
        public int PowerCap { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyPowerCapDefinition(int powerCap, bool blacklisted, uint hash, int index, bool redacted)
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

        public bool DeepEquals(DestinyPowerCapDefinition other)
        {
            return other != null &&
                   PowerCap == other.PowerCap &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
