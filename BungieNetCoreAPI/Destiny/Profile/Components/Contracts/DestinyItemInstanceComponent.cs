using BungieNetCoreAPI.Destiny.Definitions.BreakerTypes;
using BungieNetCoreAPI.Destiny.Definitions.DamageTypes;
using BungieNetCoreAPI.Destiny.Definitions.Unlocks;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace BungieNetCoreAPI.Destiny.Profile.Components.Contracts
{  
    public class DestinyItemInstanceComponent
    {
        public DamageType DamageTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; }
        public DestinyStat PrimaryStat { get; }
        public int ItemLevel { get; }
        public int Quality { get; }
        public bool IsEquipped { get; }
        public bool CanEquip { get; }
        public int EquipRequiredLevel { get; }
        public ReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>> UnlocksRequiredToEquip { get; }
        public EquipFailureReason CannotEquipReason { get; }
        public DestinyBreakerTypes? BreakerTypeEnumValue { get; }
        public DefinitionHashPointer<DestinyBreakerTypeDefinition> BreakerType { get; }
        public DestinyItemInstanceEnergy Energy { get; }

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
