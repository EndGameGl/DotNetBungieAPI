using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Profiles;

public sealed class DestinyProfileTransitoryTrackingEntry
{

    [JsonPropertyName("locationHash")]
    public uint? LocationHash { get; init; }

    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; init; }

    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }

    [JsonPropertyName("questlineItemHash")]
    public uint? QuestlineItemHash { get; init; }

    [JsonPropertyName("trackedDate")]
    public DateTime? TrackedDate { get; init; }
}
