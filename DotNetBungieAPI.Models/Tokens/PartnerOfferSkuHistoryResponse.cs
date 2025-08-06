namespace DotNetBungieAPI.Models.Tokens;

public sealed class PartnerOfferSkuHistoryResponse
{
    [JsonPropertyName("SkuIdentifier")]
    public string SkuIdentifier { get; init; }

    [JsonPropertyName("LocalizedName")]
    public string LocalizedName { get; init; }

    [JsonPropertyName("LocalizedDescription")]
    public string LocalizedDescription { get; init; }

    [JsonPropertyName("ClaimDate")]
    public DateTime ClaimDate { get; init; }

    [JsonPropertyName("AllOffersApplied")]
    public bool AllOffersApplied { get; init; }

    [JsonPropertyName("TransactionId")]
    public string TransactionId { get; init; }

    [JsonPropertyName("SkuOffers")]
    public Tokens.PartnerOfferHistoryResponse[]? SkuOffers { get; init; }
}
