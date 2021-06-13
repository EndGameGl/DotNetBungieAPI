using NetBungieAPI.Models.Destiny.Milestones;
using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Trending
{
    public sealed record TrendingEntryDestinyRitual
    {
        [JsonPropertyName("image")]
        public string Image { get; init; }

        [JsonPropertyName("icon")]
        public string Icon { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; init; }

        [JsonPropertyName("dateStart")]
        public DateTime? DateStart { get; init; }

        [JsonPropertyName("dateEnd")]
        public DateTime? DateEnd { get; init; }

        [JsonPropertyName("milestoneDetails")]
        public DestinyPublicMilestone MilestoneDetails { get; init; }

        [JsonPropertyName("eventContent")]
        public DestinyMilestoneContent EventContent { get; init; }
    }
}
