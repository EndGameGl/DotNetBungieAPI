using NetBungieApi.Attributes;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Lores
{
    /// <summary>
    /// These are definitions for in-game "Lore," meant to be narrative enhancements of the game experience.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyLoreDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyLoreDefinition : IDestinyDefinition, IDeepEquatable<DestinyLoreDefinition>
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public string Subtitle { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyLoreDefinition(DestinyDefinitionDisplayProperties displayProperties, string subtitle, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Subtitle = subtitle;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}";
        }

        public bool DeepEquals(DestinyLoreDefinition other)
        {
            return other != null &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   Subtitle == other.Subtitle &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues() { return; }
    }
}
