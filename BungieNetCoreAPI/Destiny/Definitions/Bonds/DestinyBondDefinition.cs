using Newtonsoft.Json;

namespace BungieNetCoreAPI.Destiny.Definitions.Bonds
{
    public class DestinyBondDefinition : DestinyDefinition
    {
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public uint ProvidedUnlockHash { get; }
        public uint ProvidedUnlockValueHash { get; }

        [JsonConstructor]
        private DestinyBondDefinition(DestinyDefinitionDisplayProperties displayProperties, uint providedUnlockHash, uint providedUnlockValueHash,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            DisplayProperties = displayProperties;
            ProvidedUnlockHash = providedUnlockHash;
            ProvidedUnlockValueHash = providedUnlockValueHash;
        }
    }
}
