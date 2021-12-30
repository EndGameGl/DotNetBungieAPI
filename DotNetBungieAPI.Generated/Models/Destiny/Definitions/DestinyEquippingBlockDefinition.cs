using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyEquippingBlockDefinition
{

    [JsonPropertyName("gearsetItemHash")]
    public uint? GearsetItemHash { get; init; }

    [JsonPropertyName("uniqueLabel")]
    public string UniqueLabel { get; init; }

    [JsonPropertyName("uniqueLabelHash")]
    public uint UniqueLabelHash { get; init; }

    [JsonPropertyName("equipmentSlotTypeHash")]
    public uint EquipmentSlotTypeHash { get; init; }

    [JsonPropertyName("attributes")]
    public Destiny.EquippingItemBlockAttributes Attributes { get; init; }

    [JsonPropertyName("ammoType")]
    public Destiny.DestinyAmmunitionType AmmoType { get; init; }

    [JsonPropertyName("displayStrings")]
    public List<string> DisplayStrings { get; init; }
}
