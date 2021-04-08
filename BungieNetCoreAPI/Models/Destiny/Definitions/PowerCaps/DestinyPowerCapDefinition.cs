using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.PowerCaps
{
    /// <summary>
    /// Defines a 'power cap' (limit) for gear items, based on the rarity tier and season of release.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPowerCapDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyPowerCapDefinition : IDestinyDefinition, IDeepEquatable<DestinyPowerCapDefinition>
    {
        public int PowerCap { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

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
