using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Definitions.Seasons
{
    public sealed record DestinySeasonPreviewImageDefinition : IDeepEquatable<DestinySeasonPreviewImageDefinition>
    {
        [JsonPropertyName("thumbnailImage")]
        public string ThumbnailImage { get; init; }
        [JsonPropertyName("highResImage")]
        public string HighResImage { get; init; }

        public bool DeepEquals(DestinySeasonPreviewImageDefinition other)
        {
            return other != null &&
                   ThumbnailImage == other.ThumbnailImage &&
                   HighResImage == other.HighResImage;
        }
    }
}
