namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the thumbnail icon, high-res image, and video link for promotional images
/// </summary>
public sealed record DestinySeasonPreviewImageDefinition
    : IDeepEquatable<DestinySeasonPreviewImageDefinition>
{
    /// <summary>
    ///     A thumbnail icon path to preview seasonal content, probably 480x270.
    /// </summary>
    [JsonPropertyName("thumbnailImage")]
    public BungieNetResource ThumbnailImage { get; init; }

    /// <summary>
    ///     An optional path to a high-resolution image, probably 1920x1080.
    /// </summary>
    [JsonPropertyName("highResImage")]
    public BungieNetResource HighResImage { get; init; }

    public bool DeepEquals(DestinySeasonPreviewImageDefinition other)
    {
        return other != null
            && ThumbnailImage == other.ThumbnailImage
            && HighResImage == other.HighResImage;
    }
}
