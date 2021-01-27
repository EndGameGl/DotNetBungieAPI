using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockExpressionMappings
{
    /// <summary>
    /// Empty definition at the moment
    /// </summary>
    [DestinyDefinition(type: DefinitionsEnum.DestinyUnlockExpressionMappingDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyUnlockExpressionMappingDefinition : IDestinyDefinition
    {
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }
        [JsonConstructor]
        private DestinyUnlockExpressionMappingDefinition(bool blacklisted, uint hash, int index, bool redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
