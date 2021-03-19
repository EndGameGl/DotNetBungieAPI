using NetBungieAPI.Destiny.Responses;
using Newtonsoft.Json;
using System;

namespace NetBungieAPI.Trending
{
    public class TrendingEntryDestinyRitual
    {
        public string Image { get; }
        public string Icon { get; }
        public string Title { get; }
        public string Subtitle { get; }
        public DateTime? DateStart { get; }
        public DateTime? DateEnd { get; }
        public DestinyPublicMilestone MilestoneDetails { get; }
        public DestinyMilestoneContent EventContent { get; }

        [JsonConstructor]
        internal TrendingEntryDestinyRitual(string image, string icon, string title, string subtitle, DateTime? dateStart, DateTime? dateEnd,
            DestinyPublicMilestone milestoneDetails, DestinyMilestoneContent eventContent)
        {
            Image = image;
            Icon = icon;
            Title = title;
            Subtitle = subtitle;
            DateStart = dateStart;
            DateEnd = dateEnd;
            MilestoneDetails = milestoneDetails;
            EventContent = eventContent;
        }
    }
}
