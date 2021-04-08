using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.EnemyRaces
{
    [DestinyDefinition(DefinitionsEnum.DestinyEnemyRaceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyEnemyRaceDefinition : IDestinyDefinition, IDeepEquatable<DestinyEnemyRaceDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyEnemyRaceDefinition(DestinyDisplayPropertiesDefinition displayProperties, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyEnemyRaceDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues()
        {
            return;
        }
    }
}
