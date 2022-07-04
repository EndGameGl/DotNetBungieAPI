namespace DotNetBungieAPI.Models.Tokens;

public sealed record BungieRewardDisplay
{
    [JsonPropertyName("UserRewardAvailabilityModel")]
    public UserRewardAvailabilityModel UserRewardAvailabilityModel { get; init; }
    
    [JsonPropertyName("ObjectiveDisplayProperties")]
    public RewardDisplayProperties ObjectiveDisplayProperties { get; init; }
    
    [JsonPropertyName("RewardDisplayProperties")]
    public RewardDisplayProperties RewardDisplayProperties { get; init; }
}