namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     These definitions represent faction vendors at different points in the game.
/// <para />
///     A single faction may contain multiple vendors, or the same vendor available at two different locations.
/// </summary>
public sealed class DestinyFactionVendorDefinition
{
    /// <summary>
    ///     The faction vendor hash.
    /// </summary>
    [JsonPropertyName("vendorHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition> VendorHash { get; init; }

    /// <summary>
    ///     The hash identifier for a Destination at which this vendor may be located. Each destination where a Vendor may exist will only ever have a single entry.
    /// </summary>
    [JsonPropertyName("destinationHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyDestinationDefinition> DestinationHash { get; init; }

    /// <summary>
    ///     The relative path to the background image representing this Vendor at this location, for use in a banner.
    /// </summary>
    [JsonPropertyName("backgroundImagePath")]
    public string BackgroundImagePath { get; init; }
}
