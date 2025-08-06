namespace DotNetBungieAPI.Models.Tokens;

public sealed class PartnerRewardHistoryResponse
{
    [JsonPropertyName("PartnerOffers")]
    public Tokens.PartnerOfferSkuHistoryResponse[]? PartnerOffers { get; init; }

    [JsonPropertyName("TwitchDrops")]
    public Tokens.TwitchDropHistoryResponse[]? TwitchDrops { get; init; }
}
