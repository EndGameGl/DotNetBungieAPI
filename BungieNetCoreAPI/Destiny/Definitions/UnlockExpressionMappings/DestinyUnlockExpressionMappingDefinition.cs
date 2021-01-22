using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.UnlockExpressionMappings
{
    /// <summary>
    /// Empty definition at the moment
    /// </summary>
    [DestinyDefinition(name: "DestinyUnlockExpressionMappingDefinition", presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyUnlockExpressionMappingDefinition : DestinyDefinition
    {
        [JsonConstructor]
        private DestinyUnlockExpressionMappingDefinition(bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted) { }

        public override string ToString()
        {
            return $"{Hash}";
        }
    }
}
