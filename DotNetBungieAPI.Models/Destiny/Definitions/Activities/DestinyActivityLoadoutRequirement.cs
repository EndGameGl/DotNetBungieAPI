using DotNetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

public sealed record DestinyActivityLoadoutRequirement
    : IDeepEquatable<DestinyActivityLoadoutRequirement>
{
    [JsonPropertyName("equipmentSlotHash")]
    public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; init; } =
        DefinitionHashPointer<DestinyEquipmentSlotDefinition>.Empty;

    [JsonPropertyName("allowedEquippedItemHashes")]
    public ReadOnlyCollection<
        DefinitionHashPointer<DestinyInventoryItemDefinition>
    > AllowedEquippedItems { get; init; } =
        ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>.Empty;

    [JsonPropertyName("allowedWeaponSubTypes")]
    public ReadOnlyCollection<DestinyItemSubType> AllowedWeaponSubTypes { get; init; } =
        ReadOnlyCollection<DestinyItemSubType>.Empty;

    public bool DeepEquals(DestinyActivityLoadoutRequirement other)
    {
        return other != null
            && EquipmentSlot.DeepEquals(other.EquipmentSlot)
            && AllowedEquippedItems.DeepEqualsReadOnlyCollection(other.AllowedEquippedItems)
            && AllowedWeaponSubTypes.DeepEqualsReadOnlySimpleCollection(
                other.AllowedWeaponSubTypes
            );
    }
}
