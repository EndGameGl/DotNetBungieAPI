using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Unlocks
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyUnlockDefinition, presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyUnlockDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int Scope { get; }
        /// <summary>
        /// Always 0 for now, useless
        /// </summary>
        public int UnlockType { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyUnlockDefinition(DestinyDefinitionDisplayProperties displayProperties, int scope, int unlockType, bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            Scope = scope;
            UnlockType = unlockType;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
