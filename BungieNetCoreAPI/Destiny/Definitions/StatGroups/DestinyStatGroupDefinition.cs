using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.StatGroups
{
    [DestinyDefinition(name: "DestinyStatGroupDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyStatGroupDefinition : DestinyDefinition
    {
        public int MaximumValue { get; }
        public int UiPosition { get; }
        public List<StatGroupScaledStatEntry> ScaledStats { get; }

        [JsonConstructor]
        private DestinyStatGroupDefinition(int maximumValue, int uiPosition, List<StatGroupScaledStatEntry> scaledStats,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            MaximumValue = maximumValue;
            UiPosition = uiPosition;
            ScaledStats = scaledStats;
        }

        public override string ToString()
        {
            return $"{Hash} {MaximumValue}";
        }
    }
}
