using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.StatGroups
{
    [DestinyDefinition(name: "DestinyStatGroupDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyStatGroupDefinition : IDestinyDefinition
    {
        public int MaximumValue { get; }
        public int UiPosition { get; }
        public List<StatGroupScaledStatEntry> ScaledStats { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyStatGroupDefinition(int maximumValue, int uiPosition, List<StatGroupScaledStatEntry> scaledStats,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            MaximumValue = maximumValue;
            UiPosition = uiPosition;
            ScaledStats = scaledStats;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {MaximumValue}";
        }
    }
}
