namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyActivityLoadoutRequirement
{
    [JsonPropertyName("equipmentSlotHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyEquipmentSlotDefinition> EquipmentSlotHash { get; init; }

    [JsonPropertyName("allowedEquippedItemHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? AllowedEquippedItemHashes { get; init; }

    [JsonPropertyName("allowedWeaponSubTypes")]
    public Destiny.DestinyItemSubType[]? AllowedWeaponSubTypes { get; init; }
}
