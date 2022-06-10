namespace DotNetBungieAPI.Generated.Models.Tokens;

public class UserRewardAvailabilityModel
{
    [JsonPropertyName("AvailabilityModel")]
    public Tokens.RewardAvailabilityModel? AvailabilityModel { get; set; }

    [JsonPropertyName("IsAvailableForUser")]
    public bool? IsAvailableForUser { get; set; }

    [JsonPropertyName("IsUnlockedForUser")]
    public bool? IsUnlockedForUser { get; set; }
}
