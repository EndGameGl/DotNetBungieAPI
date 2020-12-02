using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Achievements
{
    [DestinyDefinition("DestinyAchievementDefinition")]
    public class DestinyAchievementDefinition : DestinyDefinition
    {
        public int AcccumulatorThreshold { get; }        
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }       
        public int PlatformIndex { get; }
        
        [JsonConstructor]
        private DestinyAchievementDefinition(int acccumulatorThreshold, DestinyDefinitionDisplayProperties displayProperties, 
            int platformIndex, bool blacklisted, uint hash, int index, bool redacted) : base(blacklisted, hash, index, redacted)
        {
            AcccumulatorThreshold = acccumulatorThreshold;
            DisplayProperties = displayProperties;
            PlatformIndex = platformIndex;
        }

        public override string ToString()
        {
            return $"{Hash} {(DisplayProperties.Name)}";
        }
    }
}
