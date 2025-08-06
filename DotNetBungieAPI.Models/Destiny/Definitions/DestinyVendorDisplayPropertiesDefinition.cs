namespace DotNetBungieAPI.Models.Destiny.Definitions;

public sealed class DestinyVendorDisplayPropertiesDefinition
{
    /// <summary>
    ///     I regret calling this a "large icon". It's more like a medium-sized image with a picture of the vendor's mug on it, trying their best to look cool. Not what one would call an icon.
    /// </summary>
    [JsonPropertyName("largeIcon")]
    public string LargeIcon { get; init; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; init; }

    /// <summary>
    ///     If we replaced the icon with something more glitzy, this is the original icon that the vendor had according to the game's content. It may be more lame and/or have less razzle-dazzle. But who am I to tell you which icon to use.
    /// </summary>
    [JsonPropertyName("originalIcon")]
    public string OriginalIcon { get; init; }

    /// <summary>
    ///     Vendors, in addition to expected display property data, may also show some "common requirements" as statically defined definition data. This might be when a vendor accepts a single type of currency, or when the currency is unique to the vendor and the designers wanted to show that currency when you interact with the vendor.
    /// </summary>
    [JsonPropertyName("requirementsDisplay")]
    public Destiny.Definitions.DestinyVendorRequirementDisplayEntryDefinition[]? RequirementsDisplay { get; init; }

    /// <summary>
    ///     This is the icon used in parts of the game UI such as the vendor's waypoint.
    /// </summary>
    [JsonPropertyName("smallTransparentIcon")]
    public string SmallTransparentIcon { get; init; }

    /// <summary>
    ///     This is the icon used in the map overview, when the vendor is located on the map.
    /// </summary>
    [JsonPropertyName("mapIcon")]
    public string MapIcon { get; init; }

    /// <summary>
    ///     This is apparently the "Watermark". I am not certain offhand where this is actually used in the Game UI, but some people may find it useful.
    /// </summary>
    [JsonPropertyName("largeTransparentIcon")]
    public string LargeTransparentIcon { get; init; }

    [JsonPropertyName("description")]
    public string Description { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    ///     Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
    /// <para />
    ///     But usually, it will be a small square image that you can use as... well, an icon.
    /// <para />
    ///     They are currently represented as 96px x 96px images.
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; init; }

    [JsonPropertyName("iconSequences")]
    public Destiny.Definitions.Common.DestinyIconSequenceDefinition[]? IconSequences { get; init; }

    /// <summary>
    ///     If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.
    /// </summary>
    [JsonPropertyName("highResIcon")]
    public string HighResIcon { get; init; }

    [JsonPropertyName("hasIcon")]
    public bool HasIcon { get; init; }
}
