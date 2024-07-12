namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyActivityLoadoutRequirement
{
    [Destiny2Definition<Destiny.Definitions.DestinyEquipmentSlotDefinition>("Destiny.Definitions.DestinyEquipmentSlotDefinition")]
    [JsonPropertyName("equipmentSlotHash")]
    public uint? EquipmentSlotHash { get; set; }

    [Destiny2DefinitionList<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("allowedEquippedItemHashes")]
    public List<uint> AllowedEquippedItemHashes { get; set; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public List<Destiny.DestinyItemSubType> AllowedWeaponSubTypes { get; set; }
}
