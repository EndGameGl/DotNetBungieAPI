using BungieNetCoreAPI.Attributes;
using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Bonds
{
    [DestinyDefinition(type: DefinitionsEnum.DestinyBondDefinition, presentInSQLiteDB: false, shouldBeLoaded: true)]
    public class DestinyBondDefinition : IDestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint ProvidedUnlockHash { get; }
        public uint ProvidedUnlockValueHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyBondDefinition(DestinyDefinitionDisplayProperties displayProperties, uint providedUnlockHash, uint providedUnlockValueHash,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            DisplayProperties = displayProperties;
            ProvidedUnlockHash = providedUnlockHash;
            ProvidedUnlockValueHash = providedUnlockValueHash;
            Blacklisted = blacklisted;
            Hash = hash;
            Index = index;
            Redacted = redacted;
        }
    }
}
