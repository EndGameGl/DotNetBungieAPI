namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

public class DestinyProgressionDisplayPropertiesDefinition
{
    /// <summary>
    ///     When progressions show your "experience" gained, that bar has units (i.e. "Experience", "Bad Dudes Snuffed Out", whatever). This is the localized string for that unit of measurement.
    /// </summary>
    [JsonPropertyName("displayUnitsName")]
    public string DisplayUnitsName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///     Note that "icon" is sometimes misleading, and should be interpreted in the context of the entity. For instance, in Destiny 1 the DestinyRecordBookDefinition's icon was a big picture of a book.
    /// <para />
    ///     But usually, it will be a small square image that you can use as... well, an icon.
    /// <para />
    ///     They are currently represented as 96px x 96px images.
    /// </summary>
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("iconSequences")]
    public List<Destiny.Definitions.Common.DestinyIconSequenceDefinition> IconSequences { get; set; }

    /// <summary>
    ///     If this item has a high-res icon (at least for now, many things won't), then the path to that icon will be here.
    /// </summary>
    [JsonPropertyName("highResIcon")]
    public string HighResIcon { get; set; }

    [JsonPropertyName("hasIcon")]
    public bool HasIcon { get; set; }
}
