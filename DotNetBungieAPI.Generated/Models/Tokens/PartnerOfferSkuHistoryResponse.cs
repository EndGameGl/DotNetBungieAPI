namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerOfferSkuHistoryResponse
{
    [JsonPropertyName("SkuIdentifier")]
    public string? SkuIdentifier { get; set; }

    [JsonPropertyName("LocalizedName")]
    public string? LocalizedName { get; set; }

    [JsonPropertyName("LocalizedDescription")]
    public string? LocalizedDescription { get; set; }

    [JsonPropertyName("ClaimDate")]
    public DateTime? ClaimDate { get; set; }

    [JsonPropertyName("AllOffersApplied")]
    public bool? AllOffersApplied { get; set; }

    [JsonPropertyName("TransactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("SkuOffers")]
    public List<Tokens.PartnerOfferHistoryResponse> SkuOffers { get; set; }
}
