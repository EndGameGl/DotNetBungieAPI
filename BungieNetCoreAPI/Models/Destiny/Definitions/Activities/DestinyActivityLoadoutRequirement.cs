using NetBungieAPI.Models.Destiny.Definitions.EquipmentSlots;
using NetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Activities
{
    public sealed record DestinyActivityLoadoutRequirement : IDeepEquatable<DestinyActivityLoadoutRequirement>
    {
        [JsonPropertyName("equipmentSlotHash")]
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; init; }

        [JsonPropertyName("allowedEquippedItemHashes")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> AllowedEquippedItems { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>>();

        [JsonPropertyName("allowedWeaponSubTypes")]
        public ReadOnlyCollection<DestinyItemSubType> AllowedWeaponSubTypes { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyItemSubType>();

        public bool DeepEquals(DestinyActivityLoadoutRequirement other)
        {
            return other != null &&
                EquipmentSlot.DeepEquals(other.EquipmentSlot) &&
                AllowedEquippedItems.DeepEqualsReadOnlyCollections(other.AllowedEquippedItems) &&
                AllowedWeaponSubTypes.DeepEqualsReadOnlySimpleCollection(other.AllowedWeaponSubTypes);
        }
    }
}
