using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public sealed class DestinyFactionVendorDefinition
{

    [JsonPropertyName("vendorHash")]
    public uint VendorHash { get; init; }

    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; }

    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }
}
