using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Achievements
{
    /// <summary>
    /// Represents account achievements, such as Steam ones
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyAchievementDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyAchievementDefinition : IDestinyDefinition, IDeepEquatable<DestinyAchievementDefinition>
    {
        public int AcccumulatorThreshold { get; }        
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }       
        public int PlatformIndex { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyAchievementDefinition(int acccumulatorThreshold, DestinyDefinitionDisplayProperties displayProperties,  int platformIndex, 
            bool blacklisted, uint hash, int index, bool redacted)
        {
            AcccumulatorThreshold = acccumulatorThreshold;
            DisplayProperties = displayProperties;
            PlatformIndex = platformIndex;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyAchievementDefinition other)
        {
            return other != null &&
                   AcccumulatorThreshold == other.AcccumulatorThreshold &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   PlatformIndex == other.PlatformIndex &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
