namespace DotNetBungieAPI.Generated.Models.GroupsV2;

public class GroupBan : IDeepEquatable<GroupBan>
{
    [JsonPropertyName("groupId")]
    public long GroupId { get; set; }

    [JsonPropertyName("lastModifiedBy")]
    public User.UserInfoCard LastModifiedBy { get; set; }

    [JsonPropertyName("createdBy")]
    public User.UserInfoCard CreatedBy { get; set; }

    [JsonPropertyName("dateBanned")]
    public DateTime DateBanned { get; set; }

    [JsonPropertyName("dateExpires")]
    public DateTime DateExpires { get; set; }

    [JsonPropertyName("comment")]
    public string Comment { get; set; }

    [JsonPropertyName("bungieNetUserInfo")]
    public User.UserInfoCard BungieNetUserInfo { get; set; }

    [JsonPropertyName("destinyUserInfo")]
    public GroupsV2.GroupUserInfoCard DestinyUserInfo { get; set; }

    public bool DeepEquals(GroupBan? other)
    {
        return other is not null &&
               GroupId == other.GroupId &&
               (LastModifiedBy is not null ? LastModifiedBy.DeepEquals(other.LastModifiedBy) : other.LastModifiedBy is null) &&
               (CreatedBy is not null ? CreatedBy.DeepEquals(other.CreatedBy) : other.CreatedBy is null) &&
               DateBanned == other.DateBanned &&
               DateExpires == other.DateExpires &&
               Comment == other.Comment &&
               (BungieNetUserInfo is not null ? BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo) : other.BungieNetUserInfo is null) &&
               (DestinyUserInfo is not null ? DestinyUserInfo.DeepEquals(other.DestinyUserInfo) : other.DestinyUserInfo is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GroupBan? other)
    {
        if (other is null) return;
        if (GroupId != other.GroupId)
        {
            GroupId = other.GroupId;
            OnPropertyChanged(nameof(GroupId));
        }
        if (!LastModifiedBy.DeepEquals(other.LastModifiedBy))
        {
            LastModifiedBy.Update(other.LastModifiedBy);
            OnPropertyChanged(nameof(LastModifiedBy));
        }
        if (!CreatedBy.DeepEquals(other.CreatedBy))
        {
            CreatedBy.Update(other.CreatedBy);
            OnPropertyChanged(nameof(CreatedBy));
        }
        if (DateBanned != other.DateBanned)
        {
            DateBanned = other.DateBanned;
            OnPropertyChanged(nameof(DateBanned));
        }
        if (DateExpires != other.DateExpires)
        {
            DateExpires = other.DateExpires;
            OnPropertyChanged(nameof(DateExpires));
        }
        if (Comment != other.Comment)
        {
            Comment = other.Comment;
            OnPropertyChanged(nameof(Comment));
        }
        if (!BungieNetUserInfo.DeepEquals(other.BungieNetUserInfo))
        {
            BungieNetUserInfo.Update(other.BungieNetUserInfo);
            OnPropertyChanged(nameof(BungieNetUserInfo));
        }
        if (!DestinyUserInfo.DeepEquals(other.DestinyUserInfo))
        {
            DestinyUserInfo.Update(other.DestinyUserInfo);
            OnPropertyChanged(nameof(DestinyUserInfo));
        }
    }
}