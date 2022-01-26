namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerOfferClaimRequest : IDeepEquatable<PartnerOfferClaimRequest>
{
    [JsonPropertyName("PartnerOfferId")]
    public string PartnerOfferId { get; set; }

    [JsonPropertyName("BungieNetMembershipId")]
    public long BungieNetMembershipId { get; set; }

    [JsonPropertyName("TransactionId")]
    public string TransactionId { get; set; }

    public bool DeepEquals(PartnerOfferClaimRequest? other)
    {
        return other is not null &&
               PartnerOfferId == other.PartnerOfferId &&
               BungieNetMembershipId == other.BungieNetMembershipId &&
               TransactionId == other.TransactionId;
    }
}