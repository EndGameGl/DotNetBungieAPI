using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntry
    {
        [JsonPropertyName("weight")]
        public double Weight { get; init; }

        [JsonPropertyName("isFeatured")]
        public bool IsFeatured { get; init; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; init; }

        [JsonPropertyName("entityType")]
        public TrendingEntryType EntityType { get; init; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; init; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; init; }

        [JsonPropertyName("image")]
        public string Image { get; init; }

        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; init; }

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; init; }

        [JsonPropertyName("link")]
        public string Link { get; init; }

        [JsonPropertyName("webmVideo")]
        public string WebmVideo { get; init; }

        [JsonPropertyName("mp4Video")]
        public string Mp4Video { get; init; }

        [JsonPropertyName("featureImage")]
        public string FeatureImage { get; init; }

        [JsonPropertyName("items")]
        public ReadOnlyCollection<TrendingEntry> Items { get; init; } = Defaults.EmptyReadOnlyCollection<TrendingEntry>();

        [JsonPropertyName("creationDate")]
        public DateTime? CreationDate { get; init; }
    }
}
