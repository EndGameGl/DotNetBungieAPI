using BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots;
using BungieNetCoreAPI.Destiny.Definitions.InventoryItems;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Definitions.Activities
{
    public class ActivityLoadoutRequirement : IDeepEquatable<ActivityLoadoutRequirement>
    {
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlot { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyInventoryItemDefinition>> AllowedEquippedItems { get; }
        public ReadOnlyCollection<ItemSubType> AllowedWeaponSubTypes { get; }
        internal ActivityLoadoutRequirement(uint equipmentSlotHash, uint[] allowedEquippedItemHashes, ItemSubType[] allowedWeaponSubTypes)
        {
            EquipmentSlot = new DefinitionHashPointer<DestinyEquipmentSlotDefinition>(equipmentSlotHash, DefinitionsEnum.DestinyEquipmentSlotDefinition);
            AllowedEquippedItems = allowedEquippedItemHashes.DefinitionsAsReadOnlyOrEmpty<DestinyInventoryItemDefinition>(DefinitionsEnum.DestinyInventoryItemDefinition);
            AllowedWeaponSubTypes = allowedWeaponSubTypes.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(ActivityLoadoutRequirement other)
        {
            return other != null &&
                EquipmentSlot.DeepEquals(other.EquipmentSlot) &&
                AllowedEquippedItems.DeepEqualsReadOnlyCollections(other.AllowedEquippedItems) &&
                AllowedWeaponSubTypes.DeepEqualsReadOnlySimpleCollection(other.AllowedWeaponSubTypes);
        }
    }
}
