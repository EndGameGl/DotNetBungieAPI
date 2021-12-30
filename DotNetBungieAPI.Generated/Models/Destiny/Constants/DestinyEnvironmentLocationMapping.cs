using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Constants;

public sealed class DestinyEnvironmentLocationMapping
{

    [JsonPropertyName("locationHash")]
    public uint LocationHash { get; init; }

    [JsonPropertyName("activationSource")]
    public string ActivationSource { get; init; }

    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; init; }

    [JsonPropertyName("objectiveHash")]
    public uint? ObjectiveHash { get; init; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; init; }
}
