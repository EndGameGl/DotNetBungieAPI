using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyVendorAcceptedItemDefinition
{

    [JsonPropertyName("acceptedInventoryBucketHash")]
    public uint AcceptedInventoryBucketHash { get; init; }

    [JsonPropertyName("destinationInventoryBucketHash")]
    public uint DestinationInventoryBucketHash { get; init; }
}
