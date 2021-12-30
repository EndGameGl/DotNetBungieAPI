using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Entities.Items;

public sealed class DestinyItemInstanceComponent
{

    [JsonPropertyName("damageType")]
    public Destiny.DamageType DamageType { get; init; }

    [JsonPropertyName("damageTypeHash")]
    public uint? DamageTypeHash { get; init; }

    [JsonPropertyName("primaryStat")]
    public Destiny.DestinyStat PrimaryStat { get; init; }

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
    public List<uint> UnlockHashesRequiredToEquip { get; init; }

    [JsonPropertyName("cannotEquipReason")]
    public Destiny.EquipFailureReason CannotEquipReason { get; init; }

    [JsonPropertyName("breakerType")]
    public int? BreakerType { get; init; }

    [JsonPropertyName("breakerTypeHash")]
    public uint? BreakerTypeHash { get; init; }

    [JsonPropertyName("energy")]
    public Destiny.Entities.Items.DestinyItemInstanceEnergy Energy { get; init; }
}
