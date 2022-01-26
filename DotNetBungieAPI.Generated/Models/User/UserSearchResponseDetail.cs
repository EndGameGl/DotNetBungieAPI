namespace DotNetBungieAPI.Generated.Models.User;

public class UserSearchResponseDetail : IDeepEquatable<UserSearchResponseDetail>
{
    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; set; }

    [JsonPropertyName("destinyMemberships")]
    public List<User.UserInfoCard> DestinyMemberships { get; set; }

    public bool DeepEquals(UserSearchResponseDetail? other)
    {
        return other is not null &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode &&
               BungieNetMembershipId == other.BungieNetMembershipId &&
               DestinyMemberships.DeepEqualsList(other.DestinyMemberships);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(UserSearchResponseDetail? other)
    {
        if (other is null) return;
        if (BungieGlobalDisplayName != other.BungieGlobalDisplayName)
        {
            BungieGlobalDisplayName = other.BungieGlobalDisplayName;
            OnPropertyChanged(nameof(BungieGlobalDisplayName));
        }
        if (BungieGlobalDisplayNameCode != other.BungieGlobalDisplayNameCode)
        {
            BungieGlobalDisplayNameCode = other.BungieGlobalDisplayNameCode;
            OnPropertyChanged(nameof(BungieGlobalDisplayNameCode));
        }
        if (BungieNetMembershipId != other.BungieNetMembershipId)
        {
            BungieNetMembershipId = other.BungieNetMembershipId;
            OnPropertyChanged(nameof(BungieNetMembershipId));
        }
        if (!DestinyMemberships.DeepEqualsList(other.DestinyMemberships))
        {
            DestinyMemberships = other.DestinyMemberships;
            OnPropertyChanged(nameof(DestinyMemberships));
        }
    }
}