namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Vendors;

/// <summary>
///     These definitions represent vendors' locations and relevant display information at different times in the game.
/// </summary>
public class DestinyVendorLocationDefinition : IDeepEquatable<DestinyVendorLocationDefinition>
{
    /// <summary>
    ///     The hash identifier for a Destination at which this vendor may be located. Each destination where a Vendor may exist will only ever have a single entry.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public uint DestinationHash { get; set; }

    /// <summary>
    ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
    /// </summary>
    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; set; }

    public bool DeepEquals(DestinyVendorLocationDefinition? other)
    {
        return other is not null &&
               DestinationHash == other.DestinationHash &&
               BackgroundImagePath == other.BackgroundImagePath;
    }
}