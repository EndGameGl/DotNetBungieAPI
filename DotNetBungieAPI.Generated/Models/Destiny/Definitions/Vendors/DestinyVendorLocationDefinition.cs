using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Vendors;

/// <summary>
///     These definitions represent vendors' locations and relevant display information at different times in the game.
/// </summary>
public sealed class DestinyVendorLocationDefinition
{

    /// <summary>
    ///     The hash identifier for a Destination at which this vendor may be located. Each destination where a Vendor may exist will only ever have a single entry.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; init; } // DestinyDestinationDefinition

    /// <summary>
    ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
    /// </summary>
    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }
}
