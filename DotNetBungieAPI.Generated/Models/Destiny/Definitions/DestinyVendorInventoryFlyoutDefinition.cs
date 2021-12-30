using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorInventoryFlyoutDefinition
{

    [JsonPropertyName("lockedDescription")]
    public string LockedDescription { get; init; }

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("buckets")]
    public List<Destiny.Definitions.DestinyVendorInventoryFlyoutBucketDefinition> Buckets { get; init; }

    [JsonPropertyName("flyoutId")]
    public uint FlyoutId { get; init; }

    [JsonPropertyName("suppressNewness")]
    public bool SuppressNewness { get; init; }

    [JsonPropertyName("equipmentSlotHash")]
    public uint? EquipmentSlotHash { get; init; }
}
