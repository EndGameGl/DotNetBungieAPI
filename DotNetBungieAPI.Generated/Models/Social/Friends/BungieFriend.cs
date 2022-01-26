namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class BungieFriend : IDeepEquatable<BungieFriend>
{
    [JsonPropertyName("lastSeenAsMembershipId")]
    public long LastSeenAsMembershipId { get; set; }

    [JsonPropertyName("lastSeenAsBungieMembershipType")]
    public BungieMembershipType LastSeenAsBungieMembershipType { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    [JsonPropertyName("onlineStatus")]
    public Social.Friends.PresenceStatus OnlineStatus { get; set; }

    [JsonPropertyName("onlineTitle")]
    public Social.Friends.PresenceOnlineStateFlags OnlineTitle { get; set; }

    [JsonPropertyName("relationship")]
    public Social.Friends.FriendRelationshipState Relationship { get; set; }

    [JsonPropertyName("bungieNetUser")]
    public User.GeneralUser BungieNetUser { get; set; }

    public bool DeepEquals(BungieFriend? other)
    {
        return other is not null &&
               LastSeenAsMembershipId == other.LastSeenAsMembershipId &&
               LastSeenAsBungieMembershipType == other.LastSeenAsBungieMembershipType &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode &&
               OnlineStatus == other.OnlineStatus &&
               OnlineTitle == other.OnlineTitle &&
               Relationship == other.Relationship &&
               (BungieNetUser is not null ? BungieNetUser.DeepEquals(other.BungieNetUser) : other.BungieNetUser is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(BungieFriend? other)
    {
        if (other is null) return;
        if (LastSeenAsMembershipId != other.LastSeenAsMembershipId)
        {
            LastSeenAsMembershipId = other.LastSeenAsMembershipId;
            OnPropertyChanged(nameof(LastSeenAsMembershipId));
        }
        if (LastSeenAsBungieMembershipType != other.LastSeenAsBungieMembershipType)
        {
            LastSeenAsBungieMembershipType = other.LastSeenAsBungieMembershipType;
            OnPropertyChanged(nameof(LastSeenAsBungieMembershipType));
        }
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
        if (OnlineStatus != other.OnlineStatus)
        {
            OnlineStatus = other.OnlineStatus;
            OnPropertyChanged(nameof(OnlineStatus));
        }
        if (OnlineTitle != other.OnlineTitle)
        {
            OnlineTitle = other.OnlineTitle;
            OnPropertyChanged(nameof(OnlineTitle));
        }
        if (Relationship != other.Relationship)
        {
            Relationship = other.Relationship;
            OnPropertyChanged(nameof(Relationship));
        }
        if (!BungieNetUser.DeepEquals(other.BungieNetUser))
        {
            BungieNetUser.Update(other.BungieNetUser);
            OnPropertyChanged(nameof(BungieNetUser));
        }
    }
}