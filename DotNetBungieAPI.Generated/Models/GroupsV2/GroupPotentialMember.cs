namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupPotentialMember : IDeepEquatable<GroupPotentialMember>
{
    [JsonPropertyName("potentialStatus")]
    public GroupsV2.GroupPotentialMemberStatus PotentialStatus { get; set; }

    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    [JsonPropertyName("joinDate")]
    public DateTime JoinDate { get; set; }

    public bool DeepEquals(GroupPotentialMember? other)
    {
        return other is not null &&
               PotentialStatus == other.PotentialStatus &&
               GroupId == other.GroupId &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null) &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null) &&
               JoinDate == other.JoinDate;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupPotentialMember? other)
    {
        if (other is null) return;
        if (PotentialStatus != other.PotentialStatus)
        {
            PotentialStatus = other.PotentialStatus;
            OnPropertyChanged(nameof(PotentialStatus));
        }
        if (GroupId != other.GroupId)
        {
            GroupId = other.GroupId;
            OnPropertyChanged(nameof(GroupId));
        }
        if (!DestinyUserInfo.DeepEquals(other.DestinyUserInfo))
        {
            DestinyUserInfo.Update(other.DestinyUserInfo);
            OnPropertyChanged(nameof(DestinyUserInfo));
        }
        if (!BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo))
        {
            BungieNetUserInfo.Update(other.BungieNetUserInfo);
            OnPropertyChanged(nameof(BungieNetUserInfo));
        }
        if (JoinDate != other.JoinDate)
        {
            JoinDate = other.JoinDate;
            OnPropertyChanged(nameof(JoinDate));
        }
    }
}