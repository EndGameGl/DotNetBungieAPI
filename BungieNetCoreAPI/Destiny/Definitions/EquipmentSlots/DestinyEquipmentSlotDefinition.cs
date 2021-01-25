using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots
{
    [DestinyDefinition(name: "DestinyEquipmentSlotDefinition", presentInSQLiteDB: true, shouldBeLoaded: true)]
    public class DestinyEquipmentSlotDefinition : IDestinyDefinition
    {
        public bool ApplyCustomArtDyes { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        public List<EquipmentSlotArtDyeChannelEntry> ArtDyeChannels { get; }
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; }
        public uint EquipmentCategoryHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        private DestinyEquipmentSlotDefinition(bool applyCustomArtDyes, DestinyDefinitionDisplayProperties displayProperties, List<EquipmentSlotArtDyeChannelEntry> artDyeChannels,
            uint bucketTypeHash, uint equipmentCategoryHash,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            ApplyCustomArtDyes = applyCustomArtDyes;
            DisplayProperties = displayProperties;
            if (artDyeChannels == null)
                ArtDyeChannels = new List<EquipmentSlotArtDyeChannelEntry>();
            else
                ArtDyeChannels = artDyeChannels;
            BucketType = new DefinitionHashPointer<DestinyInventoryBucketDefinition>(bucketTypeHash, DefinitionsEnum.DestinyInventoryBucketDefinition);
            EquipmentCategoryHash = equipmentCategoryHash;
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
