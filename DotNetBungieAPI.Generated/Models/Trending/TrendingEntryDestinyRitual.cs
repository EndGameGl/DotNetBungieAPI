using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Trending;

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

    [JsonPropertyName("milestoneDetails")]
    public Destiny.Milestones.DestinyPublicMilestone MilestoneDetails { get; init; }

    [JsonPropertyName("eventContent")]
    public Destiny.Milestones.DestinyMilestoneContent EventContent { get; init; }
}
