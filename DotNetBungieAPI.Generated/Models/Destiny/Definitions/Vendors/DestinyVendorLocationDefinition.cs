using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Vendors;

public sealed class DestinyVendorLocationDefinition
{

    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }
}
