namespace DotNetBungieAPI.Generated.Models.Trending;

public class TrendingEntryDestinyRitual
{
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("subtitle")]
    public string Subtitle { get; set; }

    [JsonPropertyName("dateStart")]
    public DateTime? DateStart { get; set; }

    [JsonPropertyName("dateEnd")]
    public DateTime? DateEnd { get; set; }

    /// <summary>
    ///     A destiny event does not necessarily have a related Milestone, but if it does the details will be returned here.
    /// </summary>
    [JsonPropertyName("milestoneDetails")]
    public Destiny.Milestones.DestinyPublicMilestone MilestoneDetails { get; set; }

    /// <summary>
    ///     A destiny event will not necessarily have milestone "custom content", but if it does the details will be here.
    /// </summary>
    [JsonPropertyName("eventContent")]
    public Destiny.Milestones.DestinyMilestoneContent EventContent { get; set; }
}
