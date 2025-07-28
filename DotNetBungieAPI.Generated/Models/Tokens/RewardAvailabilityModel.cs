namespace DotNetBungieAPI.Generated.Models.Tokens;

public class RewardAvailabilityModel
{
    [JsonPropertyName("HasExistingCode")]
    public bool HasExistingCode { get; set; }

    [JsonPropertyName("RecordDefinitions")]
    public Destiny.Definitions.Records.DestinyRecordDefinition[]? RecordDefinitions { get; set; }

    [JsonPropertyName("CollectibleDefinitions")]
    public Tokens.CollectibleDefinitions[]? CollectibleDefinitions { get; set; }

    [JsonPropertyName("IsOffer")]
    public bool IsOffer { get; set; }

    [JsonPropertyName("HasOffer")]
    public bool HasOffer { get; set; }

    [JsonPropertyName("OfferApplied")]
    public bool OfferApplied { get; set; }

    [JsonPropertyName("DecryptedToken")]
    public string DecryptedToken { get; set; }

    [JsonPropertyName("IsLoyaltyReward")]
    public bool IsLoyaltyReward { get; set; }

    [JsonPropertyName("ShopifyEndDate")]
    public DateTime? ShopifyEndDate { get; set; }

    [JsonPropertyName("GameEarnByDate")]
    public DateTime GameEarnByDate { get; set; }

    [JsonPropertyName("RedemptionEndDate")]
    public DateTime RedemptionEndDate { get; set; }
}
