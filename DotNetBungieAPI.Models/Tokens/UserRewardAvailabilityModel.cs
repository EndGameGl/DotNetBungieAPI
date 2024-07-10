namespace DotNetBungieAPI.Models.Tokens;

public sealed record UserRewardAvailabilityModel
{
    [JsonPropertyName("AvailabilityModel")]
    public RewardAvailabilityModel AvailabilityModel { get; init; }

    [JsonPropertyName("IsAvailableForUser")]
    public bool IsAvailableForUser { get; init; }

    [JsonPropertyName("IsUnlockedForUser")]
    public bool IsUnlockedForUser { get; init; }
}
