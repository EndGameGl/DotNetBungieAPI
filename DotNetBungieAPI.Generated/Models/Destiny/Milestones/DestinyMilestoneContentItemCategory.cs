using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneContentItemCategory
{

    [JsonPropertyName("title")]
    public string Title { get; init; }

    [JsonPropertyName("itemHashes")]
    public List<uint> ItemHashes { get; init; }
}
