namespace DotNetBungieAPI.Generated.Models.Tokens;

public class BungieRewardDisplay
{
    [JsonPropertyName("UserRewardAvailabilityModel")]
    public Tokens.UserRewardAvailabilityModel UserRewardAvailabilityModel { get; set; }

    [JsonPropertyName("ObjectiveDisplayProperties")]
    public Tokens.RewardDisplayProperties ObjectiveDisplayProperties { get; set; }

    [JsonPropertyName("RewardDisplayProperties")]
    public Tokens.RewardDisplayProperties RewardDisplayProperties { get; set; }
}
