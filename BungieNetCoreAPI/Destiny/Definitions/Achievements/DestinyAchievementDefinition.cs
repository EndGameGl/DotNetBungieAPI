using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Achievements
{
    [DestinyDefinition(name: "DestinyAchievementDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyAchievementDefinition : IDestinyDefinition
    {
        public int AcccumulatorThreshold { get; }        
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }       
        public int PlatformIndex { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyAchievementDefinition(int acccumulatorThreshold, DestinyDefinitionDisplayProperties displayProperties, 
            int platformIndex, bool blacklisted, uint hash, int index, bool redacted)
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
    }
}
