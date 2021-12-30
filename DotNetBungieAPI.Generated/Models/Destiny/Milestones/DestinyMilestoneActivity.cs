using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Milestones;

public sealed class DestinyMilestoneActivity
{

    [JsonPropertyName("activityHash")]
    public uint ActivityHash { get; init; }

    [JsonPropertyName("activityModeHash")]
    public uint? ActivityModeHash { get; init; }

    [JsonPropertyName("activityModeType")]
    public int? ActivityModeType { get; init; }

    [JsonPropertyName("modifierHashes")]
    public List<uint> ModifierHashes { get; init; }

    [JsonPropertyName("variants")]
    public List<Destiny.Milestones.DestinyMilestoneActivityVariant> Variants { get; init; }
}
