using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.ProgressionMappings
{
    /// <summary>
    /// Aggregations of multiple progressions.
    /// <para/>
    /// These are used to apply rewards to multiple progressions at once.They can sometimes have human readable data as well, but only extremely sporadically.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyProgressionMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyProgressionMappingDefinition : IDestinyDefinition, IDeepEquatable<DestinyProgressionMappingDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The localized unit of measurement for progression across the progressions defined in this mapping. Unfortunately, this is very infrequently defined. Defer to the individual progressions' display units.
        /// </summary>
        public string DisplayUnits { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyProgressionMappingDefinition(DestinyDefinitionDisplayProperties displayProperties, string displayUnits, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            DisplayUnits = displayUnits;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }

        public bool DeepEquals(DestinyProgressionMappingDefinition other)
        {
            return other!= null  &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   DisplayUnits == other.DisplayUnits &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
        public void MapValues() { return; }
    }
}
