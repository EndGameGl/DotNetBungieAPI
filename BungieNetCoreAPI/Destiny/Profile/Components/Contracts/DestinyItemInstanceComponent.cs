using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Profile.Components.Contracts
{  
    public class DestinyItemInstanceComponent
    {
        public DamageType DamageTypeEnumValue { get; init; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; }
        public DestinyStat PrimaryStat { get; init; }
        public int ItemLevel { get; init; }
        public int Quality { get; init; }
        public bool IsEquipped { get; init; }
        public bool CanEquip { get; init; }
        public int EquipRequiredLevel { get; init; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>> UnlocksRequiredToEquip { get; init; }
        public EquipFailureReason CannotEquipReason { get; init; }
        public DestinyBreakerTypes? BreakerTypeEnumValue { get; init; }
        public DefinitionHashPointer<DestinyBreakerTypeDefinition> BreakerType { get; init; }
        public DestinyItemInstanceEnergy Energy { get; init; }

        [JsonConstructor]
        internal DestinyItemInstanceComponent(DamageType damageType, uint? damageTypeHash, DestinyStat primaryStat, int itemLevel, int quality,
            bool isEquipped, bool canEquip, int equipRequiredLevel, uint[] unlockHashesRequiredToEquip, EquipFailureReason cannotEquipReason,
            DestinyBreakerTypes? breakerType, uint? breakerTypeHash, DestinyItemInstanceEnergy energy)
        {
            DamageTypeEnumValue = damageType;
            DamageType = new DefinitionHashPointer<DestinyDamageTypeDefinition>(damageTypeHash, DefinitionsEnum.DestinyDamageTypeDefinition);
            PrimaryStat = primaryStat;
            ItemLevel = itemLevel;
            Quality = quality;
            IsEquipped = isEquipped;
            CanEquip = canEquip;
            EquipRequiredLevel = equipRequiredLevel;
            UnlocksRequiredToEquip = unlockHashesRequiredToEquip.DefinitionsAsReadOnlyOrEmpty<DestinyUnlockDefinition>(DefinitionsEnum.DestinyUnlockDefinition);
            CannotEquipReason = cannotEquipReason;
            BreakerTypeEnumValue = breakerType;
            BreakerType = new DefinitionHashPointer<DestinyBreakerTypeDefinition>(breakerTypeHash, DefinitionsEnum.DestinyBreakerTypeDefinition);
            Energy = energy;
        }
    }
}
