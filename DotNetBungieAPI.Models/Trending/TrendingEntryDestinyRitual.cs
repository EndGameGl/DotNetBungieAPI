namespace DotNetBungieAPI.Models.Trending;

public sealed class TrendingEntryDestinyRitual
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

    /// <summary>
    ///     A destiny event does not necessarily have a related Milestone, but if it does the details will be returned here.
    /// </summary>
    [JsonPropertyName("milestoneDetails")]
    public Destiny.Milestones.DestinyPublicMilestone? MilestoneDetails { get; init; }

    /// <summary>
    ///     A destiny event will not necessarily have milestone "custom content", but if it does the details will be here.
    /// </summary>
    [JsonPropertyName("eventContent")]
    public Destiny.Milestones.DestinyMilestoneContent? EventContent { get; init; }
}
