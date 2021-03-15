using NetBungieAPI.Attributes;
using NetBungieAPI.Destiny.Definitions.InventoryBuckets;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.EquipmentSlots
{
    /// <summary>
    /// Characters can not only have Inventory buckets (containers of items that are generally matched by their type or functionality), they can also have Equipment Slots.
    /// <para/>
    /// The Equipment Slot is an indicator that the related bucket can have instanced items equipped on the character.For instance, the Primary Weapon bucket has an Equipment Slot that determines whether you can equip primary weapons, and holds the association between its slot and the inventory bucket from which it can have items equipped.
    /// <para/>
    /// An Equipment Slot must have a related Inventory Bucket, but not all inventory buckets must have Equipment Slots.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyEquipmentSlotDefinition, DefinitionSources.All, DefinitionKeyType.UInt)]
    public class DestinyEquipmentSlotDefinition : IDestinyDefinition, IDeepEquatable<DestinyEquipmentSlotDefinition>
    {
        /// <summary>
        /// If True, equipped items should have their custom art dyes applied when rendering the item. Otherwise, custom art dyes on an item should be ignored if the item is equipped in this slot.
        /// </summary>
        public bool ApplyCustomArtDyes { get; }
        public DestinyDefinitionDisplayProperties DisplayProperties { get; }
        /// <summary>
        /// The Art Dye Channels that apply to this equipment slot.
        /// </summary>
        public ReadOnlyCollection<EquipmentSlotArtDyeChannelEntry> ArtDyeChannels { get; }
        /// <summary>
        /// The inventory bucket that owns this equipment slot.
        /// </summary>
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; }
        public uint EquipmentCategoryHash { get; }
        public bool Blacklisted { get; }
        public uint Hash { get; }
        public int Index { get; }
        public bool Redacted { get; }

        [JsonConstructor]
        internal DestinyEquipmentSlotDefinition(bool applyCustomArtDyes, DestinyDefinitionDisplayProperties displayProperties, EquipmentSlotArtDyeChannelEntry[] artDyeChannels,
            uint bucketTypeHash, uint equipmentCategoryHash,
            bool blacklisted, uint hash, int index, bool redacted)
        {
            ApplyCustomArtDyes = applyCustomArtDyes;
            DisplayProperties = displayProperties;
            ArtDyeChannels = artDyeChannels.AsReadOnlyOrEmpty();
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

        public bool DeepEquals(DestinyEquipmentSlotDefinition other)
        {
            return other != null &&
                   ApplyCustomArtDyes == other.ApplyCustomArtDyes &&
                   DisplayProperties.DeepEquals(other.DisplayProperties) &&
                   ArtDyeChannels.DeepEqualsReadOnlyCollections(other.ArtDyeChannels) &&
                   BucketType.DeepEquals(other.BucketType) &&
                   EquipmentCategoryHash == other.EquipmentCategoryHash &&
                   Blacklisted == other.Blacklisted &&
                   Hash == other.Hash &&
                   Index == other.Index &&
                   Redacted == other.Redacted;
        }

        public void MapValues()
        {
            BucketType.TryMapValue();
        }
    }
}
