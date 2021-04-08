using Newtonsoft.Json;

namespace NetBungieAPI.Destiny.Definitions.Seasons
{
    public class SeasonPreviewImage : IDeepEquatable<SeasonPreviewImage>
    {
        public string ThumbnailImage { get; init; }
        public string HighResImage { get; init; }

        [JsonConstructor]
        internal SeasonPreviewImage(string thumbnailImage, string highResImage)
        {
            ThumbnailImage = thumbnailImage;
            HighResImage = highResImage;
        }

        public bool DeepEquals(SeasonPreviewImage other)
        {
            return other != null &&
                   ThumbnailImage == other.ThumbnailImage &&
                   HighResImage == other.HighResImage;
        }
    }
}
