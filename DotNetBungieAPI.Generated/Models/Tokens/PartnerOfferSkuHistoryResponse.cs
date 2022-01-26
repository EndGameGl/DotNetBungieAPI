namespace DotNetBungieAPI.Generated.Models.Tokens;

public class PartnerOfferSkuHistoryResponse : IDeepEquatable<PartnerOfferSkuHistoryResponse>
{
    [JsonPropertyName("SkuIdentifier")]
    public string SkuIdentifier { get; set; }

    [JsonPropertyName("LocalizedName")]
    public string LocalizedName { get; set; }

    [JsonPropertyName("LocalizedDescription")]
    public string LocalizedDescription { get; set; }

    [JsonPropertyName("ClaimDate")]
    public DateTime ClaimDate { get; set; }

    [JsonPropertyName("AllOffersApplied")]
    public bool AllOffersApplied { get; set; }

    [JsonPropertyName("TransactionId")]
    public string TransactionId { get; set; }

    [JsonPropertyName("SkuOffers")]
    public List<Tokens.PartnerOfferHistoryResponse> SkuOffers { get; set; }

    public bool DeepEquals(PartnerOfferSkuHistoryResponse? other)
    {
        return other is not null &&
               SkuIdentifier == other.SkuIdentifier &&
               LocalizedName == other.LocalizedName &&
               LocalizedDescription == other.LocalizedDescription &&
               ClaimDate == other.ClaimDate &&
               AllOffersApplied == other.AllOffersApplied &&
               TransactionId == other.TransactionId &&
               SkuOffers.DeepEqualsList(other.SkuOffers);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PartnerOfferSkuHistoryResponse? other)
    {
        if (other is null) return;
        if (SkuIdentifier != other.SkuIdentifier)
        {
            SkuIdentifier = other.SkuIdentifier;
            OnPropertyChanged(nameof(SkuIdentifier));
        }
        if (LocalizedName != other.LocalizedName)
        {
            LocalizedName = other.LocalizedName;
            OnPropertyChanged(nameof(LocalizedName));
        }
        if (LocalizedDescription != other.LocalizedDescription)
        {
            LocalizedDescription = other.LocalizedDescription;
            OnPropertyChanged(nameof(LocalizedDescription));
        }
        if (ClaimDate != other.ClaimDate)
        {
            ClaimDate = other.ClaimDate;
            OnPropertyChanged(nameof(ClaimDate));
        }
        if (AllOffersApplied != other.AllOffersApplied)
        {
            AllOffersApplied = other.AllOffersApplied;
            OnPropertyChanged(nameof(AllOffersApplied));
        }
        if (TransactionId != other.TransactionId)
        {
            TransactionId = other.TransactionId;
            OnPropertyChanged(nameof(TransactionId));
        }
        if (!SkuOffers.DeepEqualsList(other.SkuOffers))
        {
            SkuOffers = other.SkuOffers;
            OnPropertyChanged(nameof(SkuOffers));
        }
    }
}