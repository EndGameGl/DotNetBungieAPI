﻿using Newtonsoft.Json;

namespace NetBungieApi.Destiny.Definitions.Seasons
{
    public class SeasonPreviewImage : IDeepEquatable<SeasonPreviewImage>
    {
        public string ThumbnailImage { get; }
        public string HighResImage { get; }

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
