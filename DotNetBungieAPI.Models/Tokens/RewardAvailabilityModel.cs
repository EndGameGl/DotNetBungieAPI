using DotNetBungieAPI.Models.Destiny.Definitions.Records;

namespace DotNetBungieAPI.Models.Tokens;

public sealed record RewardAvailabilityModel
{
    [JsonPropertyName("HasExistingCode")]
    public bool HasExistingCode { get; init; }

    [JsonPropertyName("RecordDefinitions")]
    public ReadOnlyCollection<DestinyRecordDefinition> RecordDefinitions { get; init; } =
        ReadOnlyCollections<DestinyRecordDefinition>.Empty;

    [JsonPropertyName("CollectibleDefinitions")]
    public ReadOnlyCollection<CollectibleDefinitions> CollectibleDefinitions { get; init; } =
        ReadOnlyCollections<CollectibleDefinitions>.Empty;

    [JsonPropertyName("IsOffer")]
    public bool IsOffer { get; init; }

    [JsonPropertyName("HasOffer")]
    public bool HasOffer { get; init; }

    [JsonPropertyName("OfferApplied")]
    public bool OfferApplied { get; init; }

    [JsonPropertyName("DecryptedToken")]
    public string DecryptedToken { get; init; }

    [JsonPropertyName("IsLoyaltyReward")]
    public bool IsLoyaltyReward { get; init; }

    [JsonPropertyName("ShopifyEndDate")]
    public DateTime? ShopifyEndDate { get; init; }

    [JsonPropertyName("GameEarnByDate")]
    public DateTime GameEarnByDate { get; init; }

    [JsonPropertyName("RedemptionEndDate")]
    public DateTime RedemptionEndDate { get; init; }
}
