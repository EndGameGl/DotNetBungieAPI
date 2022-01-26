namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirement : IDeepEquatable<DestinyActivityLoadoutRequirement>
{
    [JsonPropertyName("equipmentSlotHash")]
    public uint EquipmentSlotHash { get; set; }

    [JsonPropertyName("allowedEquippedItemHashes")]
    public List<uint> AllowedEquippedItemHashes { get; set; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public List<Destiny.DestinyItemSubType> AllowedWeaponSubTypes { get; set; }

    public bool DeepEquals(DestinyActivityLoadoutRequirement? other)
    {
        return other is not null &&
               EquipmentSlotHash == other.EquipmentSlotHash &&
               AllowedEquippedItemHashes.DeepEqualsListNaive(other.AllowedEquippedItemHashes) &&
               AllowedWeaponSubTypes.DeepEqualsListNaive(other.AllowedWeaponSubTypes);
    }
}