namespace DotNetBungieAPI.Models.Tokens;

public sealed record PartnerRewardHistoryResponse
{
    [JsonPropertyName("PartnerOffers")]
    public ReadOnlyCollection<PartnerOfferSkuHistoryResponse> PartnerOffers { get; init; } =
        ReadOnlyCollection<PartnerOfferSkuHistoryResponse>.Empty;

    [JsonPropertyName("TwitchDrops")]
    public ReadOnlyCollection<TwitchDropHistoryResponse> TwitchDrops { get; init; } =
        ReadOnlyCollection<TwitchDropHistoryResponse>.Empty;
}
