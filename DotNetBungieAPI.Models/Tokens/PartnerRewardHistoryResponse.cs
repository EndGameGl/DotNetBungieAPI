namespace DotNetBungieAPI.Models.Tokens;

public sealed record PartnerRewardHistoryResponse
{
    [JsonPropertyName("PartnerOffers")]
    public ReadOnlyCollection<PartnerOfferSkuHistoryResponse> PartnerOffers { get; init; } =
        ReadOnlyCollections<PartnerOfferSkuHistoryResponse>.Empty;

    [JsonPropertyName("TwitchDrops")]
    public ReadOnlyCollection<TwitchDropHistoryResponse> TwitchDrops { get; init; } =
        ReadOnlyCollections<TwitchDropHistoryResponse>.Empty;
}
