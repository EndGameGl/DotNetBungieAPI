using NetBungieAPI.Models.Destiny.Definitions.BreakerTypes;
using NetBungieAPI.Models.Destiny.Definitions.DamageTypes;
using NetBungieAPI.Models.Destiny.Definitions.Unlocks;
using NetBungieAPI.Models.Destiny.Items;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Components
{  
    public sealed record DestinyItemInstanceComponent
    {
        [JsonPropertyName("damageType")]
        public DamageType DamageTypeEnumValue { get; init; }
        [JsonPropertyName("damageTypeHash")]
        public DefinitionHashPointer<DestinyDamageTypeDefinition> DamageType { get; init; } = DefinitionHashPointer<DestinyDamageTypeDefinition>.Empty;
        [JsonPropertyName("primaryStat")]
        public DestinyStat PrimaryStat { get; init; }
        [JsonPropertyName("itemLevel")]
        public int ItemLevel { get; init; }
        [JsonPropertyName("quality")]
        public int Quality { get; init; }
        [JsonPropertyName("isEquipped")]
        public bool IsEquipped { get; init; }
        [JsonPropertyName("canEquip")]
        public bool CanEquip { get; init; }
        [JsonPropertyName("equipRequiredLevel")]
        public int EquipRequiredLevel { get; init; }
        [JsonPropertyName("unlockHashesRequiredToEquip")]
        public ReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>> UnlocksRequiredToEquip { get; init; } = Defaults.EmptyReadOnlyCollection<DefinitionHashPointer<DestinyUnlockDefinition>>();
        [JsonPropertyName("cannotEquipReason")]
        public EquipFailureReason CannotEquipReason { get; init; }
        [JsonPropertyName("breakerType")]
        public DestinyBreakerType? BreakerTypeEnumValue { get; init; }
        [JsonPropertyName("breakerTypeHash")]
        public DefinitionHashPointer<DestinyBreakerTypeDefinition> BreakerType { get; init; } = DefinitionHashPointer<DestinyBreakerTypeDefinition>.Empty;
        [JsonPropertyName("energy")]
        public DestinyItemInstanceEnergy Energy { get; init; }
    }
}
