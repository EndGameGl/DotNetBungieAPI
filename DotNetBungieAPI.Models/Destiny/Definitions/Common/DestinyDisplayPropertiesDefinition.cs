namespace DotNetBungieAPI.Models.Destiny.Definitions.Common;

/// <summary>
///     Many Destiny*Definition contracts - the "first order" entities of Destiny that have their own tables in the Manifest Database - also have displayable information. This is the base class for that display information.
/// </summary>
public sealed class DestinyDisplayPropertiesDefinition
{
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
