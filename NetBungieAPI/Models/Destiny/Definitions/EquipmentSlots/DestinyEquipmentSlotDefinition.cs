using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny.Definitions.Common;
using NetBungieAPI.Models.Destiny.Definitions.InventoryBuckets;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots
{
    /// <summary>
    /// Characters can not only have Inventory buckets (containers of items that are generally matched by their type or functionality), they can also have Equipment Slots.
    /// <para/>
    /// The Equipment Slot is an indicator that the related bucket can have instanced items equipped on the character.For instance, the Primary Weapon bucket has an Equipment Slot that determines whether you can equip primary weapons, and holds the association between its slot and the inventory bucket from which it can have items equipped.
    /// <para/>
    /// An Equipment Slot must have a related Inventory Bucket, but not all inventory buckets must have Equipment Slots.
    /// </summary>
    [DestinyDefinition(DefinitionsEnum.DestinyEquipmentSlotDefinition)]
    public sealed record DestinyEquipmentSlotDefinition : IDestinyDefinition,
        IDeepEquatable<DestinyEquipmentSlotDefinition>
    {
        [JsonPropertyName("displayProperties")]
        public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

        /// <summary>
        /// These technically point to "Equipment Category Definitions". But don't get excited. There's nothing of significant value in those definitions, so I didn't bother to expose them. You can use the hash here to group equipment slots by common functionality, which serves the same purpose as if we had the Equipment Category definitions exposed.
        /// </summary>
        [JsonPropertyName("equipmentCategoryHash")]
        public uint EquipmentCategoryHash { get; init; }

        /// <summary>
        /// The inventory bucket that owns this equipment slot.
        /// </summary>
        [JsonPropertyName("bucketTypeHash")]
        public DefinitionHashPointer<DestinyInventoryBucketDefinition> BucketType { get; init; }

        /// <summary>
        /// If True, equipped items should have their custom art dyes applied when rendering the item. Otherwise, custom art dyes on an item should be ignored if the item is equipped in this slot.
        /// </summary>
        [JsonPropertyName("applyCustomArtDyes")]
        public bool ApplyCustomArtDyes { get; init; }

        /// <summary>
        /// The Art Dye Channels that apply to this equipment slot.
        /// </summary>
        [JsonPropertyName("artDyeChannels")]
        public ReadOnlyCollection<DestinyArtDyeReference> ArtDyeChannels { get; init; } =
            Defaults.EmptyReadOnlyCollection<DestinyArtDyeReference>();

        [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }
        [JsonPropertyName("hash")] public uint Hash { get; init; }
        [JsonPropertyName("index")] public int Index { get; init; }
        [JsonPropertyName("redacted")] public bool Redacted { get; init; }


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