namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerOfferHistoryResponse : IDeepEquatable<PartnerOfferHistoryResponse>
{
    [JsonPropertyName("PartnerOfferKey")]
    public string PartnerOfferKey { get; set; }

    [JsonPropertyName("MembershipId")]
    public long? MembershipId { get; set; }

    [JsonPropertyName("MembershipType")]
    public int? MembershipType { get; set; }

    [JsonPropertyName("LocalizedName")]
    public string LocalizedName { get; set; }

    [JsonPropertyName("LocalizedDescription")]
    public string LocalizedDescription { get; set; }

    [JsonPropertyName("IsConsumable")]
    public bool IsConsumable { get; set; }

    [JsonPropertyName("QuantityApplied")]
    public int QuantityApplied { get; set; }

    [JsonPropertyName("ApplyDate")]
    public DateTime? ApplyDate { get; set; }

    public bool DeepEquals(PartnerOfferHistoryResponse? other)
    {
        return other is not null &&
               PartnerOfferKey == other.PartnerOfferKey &&
               MembershipId == other.MembershipId &&
               MembershipType == other.MembershipType &&
               LocalizedName == other.LocalizedName &&
               LocalizedDescription == other.LocalizedDescription &&
               IsConsumable == other.IsConsumable &&
               QuantityApplied == other.QuantityApplied &&
               ApplyDate == other.ApplyDate;
    }
}