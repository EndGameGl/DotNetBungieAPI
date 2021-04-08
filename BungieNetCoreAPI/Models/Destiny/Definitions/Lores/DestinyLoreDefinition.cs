using NetBungieAPI.Attributes;
using Newtonsoft.Json;

namespace NetBungieAPI.Models.Destiny.Definitions.Lores
{
    /// <summary>
    /// These are definitions for in-game "Lore," meant to be narrative enhancements of the game experience.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyLoreDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyLoreDefinition : IDestinyDefinition, IDeepEquatable<DestinyLoreDefinition>
    {
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }
        public string Subtitle { get; init; }
        public bool Blacklisted { get; init; }
        public uint Hash { get; init; }
        public int Index { get; init; }
        public bool Redacted { get; init; }

        [JsonConstructor]
        internal DestinyLoreDefinition(DestinyDisplayPropertiesDefinition displayProperties, string subtitle, bool blacklisted, uint hash, int index, bool redacted)
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
