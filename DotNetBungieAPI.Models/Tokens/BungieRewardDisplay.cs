namespace DotNetBungieAPI.Models.Tokens;

public sealed class BungieRewardDisplay
{
    [JsonPropertyName("UserRewardAvailabilityModel")]
    public Tokens.UserRewardAvailabilityModel? UserRewardAvailabilityModel { get; init; }

    [JsonPropertyName("ObjectiveDisplayProperties")]
    public Tokens.RewardDisplayProperties? ObjectiveDisplayProperties { get; init; }

    [JsonPropertyName("RewardDisplayProperties")]
    public Tokens.RewardDisplayProperties? RewardDisplayProperties { get; init; }
}
