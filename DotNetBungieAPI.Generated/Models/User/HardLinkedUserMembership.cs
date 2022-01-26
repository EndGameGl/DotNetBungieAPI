namespace DotNetBungieAPI.Generated.Models.User;

public class HardLinkedUserMembership : IDeepEquatable<HardLinkedUserMembership>
{
    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    [JsonPropertyName("CrossSaveOverriddenType")]
    public BungieMembershipType CrossSaveOverriddenType { get; set; }

    [JsonPropertyName("CrossSaveOverriddenMembershipId")]
    public long? CrossSaveOverriddenMembershipId { get; set; }

    public bool DeepEquals(HardLinkedUserMembership? other)
    {
        return other is not null &&
               MembershipType == other.MembershipType &&
               MembershipId == other.MembershipId &&
               CrossSaveOverriddenType == other.CrossSaveOverriddenType &&
               CrossSaveOverriddenMembershipId == other.CrossSaveOverriddenMembershipId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(HardLinkedUserMembership? other)
    {
        if (other is null) return;
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
        if (MembershipId != other.MembershipId)
        {
            MembershipId = other.MembershipId;
            OnPropertyChanged(nameof(MembershipId));
        }
        if (CrossSaveOverriddenType != other.CrossSaveOverriddenType)
        {
            CrossSaveOverriddenType = other.CrossSaveOverriddenType;
            OnPropertyChanged(nameof(CrossSaveOverriddenType));
        }
        if (CrossSaveOverriddenMembershipId != other.CrossSaveOverriddenMembershipId)
        {
            CrossSaveOverriddenMembershipId = other.CrossSaveOverriddenMembershipId;
            OnPropertyChanged(nameof(CrossSaveOverriddenMembershipId));
        }
    }
}