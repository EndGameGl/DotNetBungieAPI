namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerRewardHistoryResponse
{
    [JsonPropertyName("PartnerOffers")]
    public List<Tokens.PartnerOfferSkuHistoryResponse> PartnerOffers { get; set; }

    [JsonPropertyName("TwitchDrops")]
    public List<Tokens.TwitchDropHistoryResponse> TwitchDrops { get; set; }
}
