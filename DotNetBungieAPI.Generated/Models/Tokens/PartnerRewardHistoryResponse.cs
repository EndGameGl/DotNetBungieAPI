namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerRewardHistoryResponse
{
    [JsonPropertyName("PartnerOffers")]
    public Tokens.PartnerOfferSkuHistoryResponse[]? PartnerOffers { get; set; }

    [JsonPropertyName("TwitchDrops")]
    public Tokens.TwitchDropHistoryResponse[]? TwitchDrops { get; set; }
}
