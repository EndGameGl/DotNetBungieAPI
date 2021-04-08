using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.Places
{
    /// <summary>
    /// Activities (DestinyActivityDefinition) take place in Destinations (DestinyDestinationDefinition). Destinations are part of larger locations known as Places
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPlaceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyPlaceDefinition : IDestinyDefinition, IDeepEquatable<DestinyPlaceDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyPlaceDefinition(DestinyDisplayPropertiesDefinition displayProperties, bool blacklisted, uint hash, int index, bool redacted)
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

        public bool DeepEquals(DestinyPlaceDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues() { return; }
    }
}
