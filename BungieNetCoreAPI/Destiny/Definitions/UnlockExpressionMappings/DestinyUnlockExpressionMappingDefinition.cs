using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockExpressionMappings
{
    /// <summary>
    /// Empty definition at the moment
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyUnlockExpressionMappingDefinition, DefinitionSources.BungieNet | DefinitionSources.JSON, DefinitionKeyType.UInt)]
    public class DestinyUnlockExpressionMappingDefinition : IDestinyDefinition, IDeepEquatable<DestinyUnlockExpressionMappingDefinition>
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyUnlockExpressionMappingDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
        public void MapValues()
        {
            return;
        }
        public bool DeepEquals(DestinyUnlockExpressionMappingDefinition other)
        {
            return other != null &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }
    }
}
