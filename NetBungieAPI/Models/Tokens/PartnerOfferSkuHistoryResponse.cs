using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Tokens
{
    public sealed record PartnerOfferSkuHistoryResponse
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
        public ReadOnlyCollection<PartnerOfferHistoryResponse> SkuOffers { get; init; } =
            Defaults.EmptyReadOnlyCollection<PartnerOfferHistoryResponse>();
    }
}