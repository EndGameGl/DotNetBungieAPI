namespace DotNetBungieAPI.Models.Tokens;

public sealed class PartnerOfferClaimRequest
{
    [JsonPropertyName("PartnerOfferId")]
    public string PartnerOfferId { get; init; }

    [JsonPropertyName("BungieNetMembershipId")]
    public long BungieNetMembershipId { get; init; }

    [JsonPropertyName("TransactionId")]
    public string TransactionId { get; init; }
}
