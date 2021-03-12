using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.StatGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyStatGroupDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyStatGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatGroupDefinition>
    {
        public int MaximumValue { get; }
        public int UiPosition { get; }
        public ReadOnlyCollection<StatGroupScaledStat> ScaledStats { get; }
        public ReadOnlyDictionary<uint, StatOverride> Overrides { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyStatGroupDefinition(int maximumValue, int uiPosition, StatGroupScaledStat[] scaledStats, Dictionary<uint, StatOverride> overrides,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            MaximumValue = maximumValue;
            UiPosition = uiPosition;
            ScaledStats = scaledStats.AsReadOnlyOrEmpty();
            Overrides = overrides.AsReadOnlyDictionaryOrEmpty();
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {MaximumValue}";
        }

        public void MapValues()
        {
            foreach (var stat in ScaledStats)
            {
                stat.Stat.TryMapValue();
            }
            foreach (var value in Overrides.Values)
            {
                value.Stat.TryMapValue();
            }
        }

        public bool DeepEquals(DestinyStatGroupDefinition other)
        {
            return other != null &&
                   MaximumValue == other.MaximumValue &&
                   UiPosition == other.UiPosition &&
                   ScaledStats.DeepEqualsReadOnlyCollections(other.ScaledStats) &&
                   Overrides.DeepEqualsReadOnlyDictionaryWithSimpleKeyAndEquatableValue(other.Overrides) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
