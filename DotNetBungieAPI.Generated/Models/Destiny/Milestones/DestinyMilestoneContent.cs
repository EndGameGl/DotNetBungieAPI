using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneContent
{

    [JsonPropertyName("about")]
    public string About { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("tips")]
    public List<string> Tips { get; init; }

    [JsonPropertyName("itemCategories")]
    public List<Destiny.Milestones.DestinyMilestoneContentItemCategory> ItemCategories { get; init; }
}
