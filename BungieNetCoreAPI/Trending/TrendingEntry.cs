using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace NetBungieAPI.Trending
{
    public class TrendingEntry
    {
        public double Weight { get; }
        public bool IsFeatured { get; }
        public string Identifier { get; }
        public TrendingEntryType EntityType { get; }
        public string DisplayName { get; }
        public string Tagline { get; }
        public string Image { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public string Link { get; }
        public string WebmVideo { get; }
        public string Mp4Video { get; }
        public string FeatureImage { get; }
        public ReadOnlyCollection<TrendingEntry> Items { get; }
        public DateTime? CreationDate { get; }

        [JsonConstructor]
        internal TrendingEntry(double weight, bool isFeatured, string identifier, TrendingEntryType entityType, string displayName, string tagline,
            string image, DateTime? startDate, DateTime? endDate, string link, string webmVideo, string mp4Video, string featureImage, TrendingEntry[] items,
            DateTime? creationDate)
        {
            Weight = weight;
            IsFeatured = isFeatured;
            Identifier = identifier;
            EntityType = entityType;
            DisplayName = displayName;
            Tagline = tagline;
            Image = image;
            StartDate = startDate;
            EndDate = endDate;
            Link = link;
            WebmVideo = webmVideo;
            Mp4Video = mp4Video;
            FeatureImage = featureImage;
            Items = items.AsReadOnlyOrEmpty();
            CreationDate = creationDate;
        }
    }
}
