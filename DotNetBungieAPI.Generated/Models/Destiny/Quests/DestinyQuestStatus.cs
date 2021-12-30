using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Quests;

public sealed class DestinyQuestStatus
{

    [JsonPropertyName("questHash")]
    public uint QuestHash { get; init; }

    [JsonPropertyName("stepHash")]
    public uint StepHash { get; init; }

    [JsonPropertyName("stepObjectives")]
    public List<Destiny.Quests.DestinyObjectiveProgress> StepObjectives { get; init; }

    [JsonPropertyName("tracked")]
    public bool Tracked { get; init; }

    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    [JsonPropertyName("completed")]
    public bool Completed { get; init; }

    [JsonPropertyName("redeemed")]
    public bool Redeemed { get; init; }

    [JsonPropertyName("started")]
    public bool Started { get; init; }

    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; init; }
}
