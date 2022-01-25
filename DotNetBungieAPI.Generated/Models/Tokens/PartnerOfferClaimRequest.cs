namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerOfferClaimRequest
{
    [JsonPropertyName("PartnerOfferId")]
    public string PartnerOfferId { get; set; }

    [JsonPropertyName("BungieNetMembershipId")]
    public long BungieNetMembershipId { get; set; }

    [JsonPropertyName("TransactionId")]
    public string TransactionId { get; set; }
}
