namespace DotNetBungieAPI.Models.Tokens;

public sealed class UserRewardAvailabilityModel
{
    [JsonPropertyName("AvailabilityModel")]
    public Tokens.RewardAvailabilityModel? AvailabilityModel { get; init; }

    [JsonPropertyName("IsAvailableForUser")]
    public bool IsAvailableForUser { get; init; }

    [JsonPropertyName("IsUnlockedForUser")]
    public bool IsUnlockedForUser { get; init; }
}
