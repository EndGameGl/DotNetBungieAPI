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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PartnerOfferClaimRequest? other)
    {
        if (other is null) return;
        if (PartnerOfferId != other.PartnerOfferId)
        {
            PartnerOfferId = other.PartnerOfferId;
            OnPropertyChanged(nameof(PartnerOfferId));
        }
        if (BungieNetMembershipId != other.BungieNetMembershipId)
        {
            BungieNetMembershipId = other.BungieNetMembershipId;
            OnPropertyChanged(nameof(BungieNetMembershipId));
        }
        if (TransactionId != other.TransactionId)
        {
            TransactionId = other.TransactionId;
            OnPropertyChanged(nameof(TransactionId));
        }
    }
}