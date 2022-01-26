namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the thumbnail icon, high-res image, and video link for promotional images
/// </summary>
public class DestinySeasonPreviewImageDefinition : IDeepEquatable<DestinySeasonPreviewImageDefinition>
{
    /// <summary>
    ///     A thumbnail icon path to preview seasonal content, probably 480x270.
    /// </summary>
    [JsonPropertyName("thumbnailImage")]
    public string ThumbnailImage { get; set; }

    /// <summary>
    ///     An optional path to a high-resolution image, probably 1920x1080.
    /// </summary>
    [JsonPropertyName("highResImage")]
    public string HighResImage { get; set; }

    public bool DeepEquals(DestinySeasonPreviewImageDefinition? other)
    {
        return other is not null &&
               ThumbnailImage == other.ThumbnailImage &&
               HighResImage == other.HighResImage;
    }
}