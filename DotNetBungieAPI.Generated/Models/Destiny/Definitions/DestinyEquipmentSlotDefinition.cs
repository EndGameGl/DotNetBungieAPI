using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Characters can not only have Inventory buckets (containers of items that are generally matched by their type or functionality), they can also have Equipment Slots.
/// <para />
///     The Equipment Slot is an indicator that the related bucket can have instanced items equipped on the character. For instance, the Primary Weapon bucket has an Equipment Slot that determines whether you can equip primary weapons, and holds the association between its slot and the inventory bucket from which it can have items equipped.
/// <para />
///     An Equipment Slot must have a related Inventory Bucket, but not all inventory buckets must have Equipment Slots.
/// </summary>
public sealed class DestinyEquipmentSlotDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     These technically point to "Equipment Category Definitions". But don't get excited. There's nothing of significant value in those definitions, so I didn't bother to expose them. You can use the hash here to group equipment slots by common functionality, which serves the same purpose as if we had the Equipment Category definitions exposed.
    /// </summary>
    [JsonPropertyName("equipmentCategoryHash")]
    public uint EquipmentCategoryHash { get; init; }

    /// <summary>
    ///     The inventory bucket that owns this equipment slot.
    /// </summary>
    [JsonPropertyName("bucketTypeHash")]
    public uint BucketTypeHash { get; init; }

    /// <summary>
    ///     If True, equipped items should have their custom art dyes applied when rendering the item. Otherwise, custom art dyes on an item should be ignored if the item is equipped in this slot.
    /// </summary>
    [JsonPropertyName("applyCustomArtDyes")]
    public bool ApplyCustomArtDyes { get; init; }

    /// <summary>
    ///     The Art Dye Channels that apply to this equipment slot.
    /// </summary>
    [JsonPropertyName("artDyeChannels")]
    public List<Destiny.Definitions.DestinyArtDyeReference> ArtDyeChannels { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
