namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirement
{
    [Destiny2Definition<Destiny.Definitions.DestinyEquipmentSlotDefinition>("Destiny.Definitions.DestinyEquipmentSlotDefinition")]
    [JsonPropertyName("equipmentSlotHash")]
    public uint EquipmentSlotHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("allowedEquippedItemHashes")]
    public uint[]? AllowedEquippedItemHashes { get; set; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public Destiny.DestinyItemSubType[]? AllowedWeaponSubTypes { get; set; }
}
