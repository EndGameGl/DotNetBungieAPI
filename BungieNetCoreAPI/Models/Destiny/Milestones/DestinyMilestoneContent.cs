using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Destiny.Milestones
{
    public sealed record DestinyMilestoneContent
    {
        [JsonPropertyName("about")]
        public string About { get; init; }
        [JsonPropertyName("status")]
        public string Status { get; init; }
        [JsonPropertyName("tips")]
        public ReadOnlyCollection<string> Tips { get; init; } = Defaults.EmptyReadOnlyCollection<string>();
        [JsonPropertyName("itemCategories")]
        public ReadOnlyCollection<DestinyMilestoneContentItemCategory> ItemCategories { get; init; } = Defaults.EmptyReadOnlyCollection<DestinyMilestoneContentItemCategory>();
    }
}
