using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Destiny.Definitions.Seasons
{
    public class SeasonPreview : IDeepEquatable<SeasonPreview>
    {
        public string Description { get; }
        public string LinkPath { get; }
        public string VideoLink { get; }
        public ReadOnlyCollection<SeasonPreviewImage> Images { get; }

        [JsonConstructor]
        internal SeasonPreview(string description, string linkPath, string videoLink, SeasonPreviewImage[] images)
        {
            Description = description;
            LinkPath = linkPath;
            VideoLink = videoLink;
            Images = images.AsReadOnlyOrEmpty();
        }

        public bool DeepEquals(SeasonPreview other)
        {
            return other != null &&
                   Description == other.Description &&
                   LinkPath == other.LinkPath &&
                   VideoLink == other.VideoLink &&
                   Images.DeepEqualsReadOnlyCollections(other.Images);
        }
    }
}
