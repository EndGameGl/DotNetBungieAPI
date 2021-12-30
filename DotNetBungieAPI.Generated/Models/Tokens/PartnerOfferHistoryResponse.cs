using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Tokens;

public sealed class PartnerOfferHistoryResponse
{

    [JsonPropertyName("PartnerOfferKey")]
    public string PartnerOfferKey { get; init; }

    [JsonPropertyName("MembershipId")]
    public long? MembershipId { get; init; }

    [JsonPropertyName("MembershipType")]
    public int? MembershipType { get; init; }

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
