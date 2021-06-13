using System;
using System.Text.Json.Serialization;

namespace NetBungieAPI.Models.Tokens
{
    public sealed record PartnerOfferHistoryResponse
    {
        [JsonPropertyName("PartnerOfferKey")]
        public string PartnerOfferKey { get; init; }
        
        [JsonPropertyName("MembershipId"), JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long MembershipId { get; init; }
        
        [JsonPropertyName("MembershipType")]
        public BungieMembershipType? MembershipType { get; init; }
        
        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; init; }
        
        [JsonPropertyName("LocalizedDescription")]
        public string LocalizedDescription { get; init; }
        
        [JsonPropertyName("IsConsumable")]
        public bool IsConsumable { get; init; }
        
        [JsonPropertyName("QuantityApplied")]
        public int QuantityApplied { get; init; }
        
        [JsonPropertyName("ApplyDate")]
        public DateTime? ApplyDate { get; init; }
    }
}