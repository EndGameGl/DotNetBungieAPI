using BungieNetCoreAPI.Destiny.Definitions.EquipmentSlots;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Destiny.Definitions.InventoryItems
{
    public class InventoryItemEquippingBlock
    {
        public DestinyAmmoType AmmoType { get; }
        public EquippingBlockAttributes Attributes { get; }
        public List<string> DisplayStrings { get; }
        public DefinitionHashPointer<DestinyEquipmentSlotDefinition> EquipmentSlotType { get; }
        public uint EquippingSoundHash { get; }
        public uint HornSoundHash { get; }
        public uint UniqueLabelHash { get; }

        [JsonConstructor]
        private InventoryItemEquippingBlock(DestinyAmmoType ammoType, EquippingBlockAttributes attributes, List<string> displayStrings, uint equipmentSlotTypeHash,
            uint equippingSoundHash, uint hornSoundHash, uint uniqueLabelHash)
        {
            AmmoType = ammoType;
            Attributes = attributes;
            DisplayStrings = displayStrings;
            EquipmentSlotType = new DefinitionHashPointer<DestinyEquipmentSlotDefinition>(equipmentSlotTypeHash, "DestinyEquipmentSlotDefinition", GlobalDefinitionsCacheRepository.CurrentLocaleLoadContext);
            EquippingSoundHash = equippingSoundHash;
            HornSoundHash = hornSoundHash;
            UniqueLabelHash = uniqueLabelHash;
        }
    }
}
