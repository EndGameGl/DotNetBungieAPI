using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyActivityLoadoutRequirement
{

    [JsonPropertyName("equipmentSlotHash")]
    public uint EquipmentSlotHash { get; init; } // DestinyEquipmentSlotDefinition

    [JsonPropertyName("allowedEquippedItemHashes")]
    public List<uint> AllowedEquippedItemHashes { get; init; } // DestinyInventoryItemDefinition

    [JsonPropertyName("allowedWeaponSubTypes")]
    public List<Destiny.DestinyItemSubType> AllowedWeaponSubTypes { get; init; }
}
