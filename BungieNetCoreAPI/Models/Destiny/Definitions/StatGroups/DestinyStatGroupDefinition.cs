using NetBungieAPI.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Models.Destiny.Definitions.StatGroups
{
    [DestinyDefinition(DefinitionsEnum.DestinyStatGroupDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyStatGroupDefinition : IDestinyDefinition, IDeepEquatable<DestinyStatGroupDefinition>
    {
        public int MaximumValue { get; init; }
        public int UiPosition { get; init; }
        public ReadOnlyCollection<StatGroupScaledStat> ScaledStats { get; init; }
        public ReadOnlyDictionary<uint, StatOverride> Overrides { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

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
