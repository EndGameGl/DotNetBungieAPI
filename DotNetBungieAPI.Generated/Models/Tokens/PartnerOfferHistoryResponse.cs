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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PartnerOfferHistoryResponse? other)
    {
        if (other is null) return;
        if (PartnerOfferKey != other.PartnerOfferKey)
        {
            PartnerOfferKey = other.PartnerOfferKey;
            OnPropertyChanged(nameof(PartnerOfferKey));
        }
        if (MembershipId != other.MembershipId)
        {
            MembershipId = other.MembershipId;
            OnPropertyChanged(nameof(MembershipId));
        }
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
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
        if (IsConsumable != other.IsConsumable)
        {
            IsConsumable = other.IsConsumable;
            OnPropertyChanged(nameof(IsConsumable));
        }
        if (QuantityApplied != other.QuantityApplied)
        {
            QuantityApplied = other.QuantityApplied;
            OnPropertyChanged(nameof(QuantityApplied));
        }
        if (ApplyDate != other.ApplyDate)
        {
            ApplyDate = other.ApplyDate;
            OnPropertyChanged(nameof(ApplyDate));
        }
    }
}