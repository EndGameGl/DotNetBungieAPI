using NetBungieApi.Destiny.Definitions.InventoryItems;
using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Artifacts
{
    public class ArtifactTierEntryItemEntry : IDeepEquatable<ArtifactTierEntryItemEntry>
    {
        public uint ActiveUnlockHash { get; }
        /// <summary>
        /// Plug Item unlocked by activating this item in the Artifact.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryItemDefinition> Item { get; }

        [JsonConstructor]
        internal ArtifactTierEntryItemEntry(uint activeUnlockHash, uint itemHash)
        {
            ActiveUnlockHash = activeUnlockHash;
            Item = new DefinitionHashPointer<DestinyInventoryItemDefinition>(itemHash, DefinitionsEnum.DestinyInventoryItemDefinition);
        }

        public bool DeepEquals(ArtifactTierEntryItemEntry other)
        {
            return other != null &&
                ActiveUnlockHash == other.ActiveUnlockHash &&
                Item.DeepEquals(other.Item);
        }
    }
}
