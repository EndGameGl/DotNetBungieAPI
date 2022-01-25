namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirement
{
    [JsonPropertyName("equipmentSlotHash")]
    public uint EquipmentSlotHash { get; set; }

    [JsonPropertyName("allowedEquippedItemHashes")]
    public List<uint> AllowedEquippedItemHashes { get; set; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public List<Destiny.DestinyItemSubType> AllowedWeaponSubTypes { get; set; }
}
