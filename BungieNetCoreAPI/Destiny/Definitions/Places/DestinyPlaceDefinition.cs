using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Places
{
    /// <summary>
    /// Activities (DestinyActivityDefinition) take place in Destinations (DestinyDestinationDefinition). Destinations are part of larger locations known as Places
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyPlaceDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyPlaceDefinition : IDestinyDefinition, IDeepEquatable<DestinyPlaceDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyPlaceDefinition(DestinyDefinitionDisplayProperties displayProperties, bool blacklisted, uint hash, int index, bool redacted)
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
