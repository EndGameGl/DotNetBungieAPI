using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots
{
    [DestinyDefinition(name: "DestinyEquipmentSlotDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyEquipmentSlotDefinition : DestinyDefinition
    {
        public bool ApplyCustomArtDyes { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<EquipmentSlotArtDyeChannelEntry> ArtDyeChannels { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; }
        public uint EquipmentCategoryHash { get; }

        [JsonConstructor]
        private DestinyEquipmentSlotDefinition(bool applyCustomArtDyes, DestinyDefinitionDisplayProperties displayProperties, List<EquipmentSlotArtDyeChannelEntry> artDyeChannels,
            uint bucketTypeHash, uint equipmentCategoryHash,
            bool blacklisted, uint hash, int index, bool redacted)
            : base(blacklisted, hash, index, redacted)
        {
            ApplyCustomArtDyes = applyCustomArtDyes;
            DisplayProperties = displayProperties;
            if (artDyeChannels == null)
                ArtDyeChannels = new List<EquipmentSlotArtDyeChannelEntry>();
            else
                ArtDyeChannels = artDyeChannels;
            BucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketTypeHash, "DestinyInventoryBucketDefinition");
            EquipmentCategoryHash = equipmentCategoryHash;
        }

        public override string ToString()
        {
            return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
        }
    }
}
