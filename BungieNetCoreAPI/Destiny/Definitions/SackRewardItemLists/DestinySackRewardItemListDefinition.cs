using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.SackRewardItemLists
{
    /// <summary>
    /// Empty definition
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinySackRewardItemListDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinySackRewardItemListDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinySackRewardItemListDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
