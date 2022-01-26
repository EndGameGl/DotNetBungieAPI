namespace DotNetBungieAPI.Generated.Models.Social.Friends;

public class PlatformFriend : IDeepEquatable<PlatformFriend>
{
    [JsonPropertyName("platformDisplayName")]
    public string PlatformDisplayName { get; set; }

    [JsonPropertyName("friendPlatform")]
    public Social.Friends.PlatformFriendType FriendPlatform { get; set; }

    [JsonPropertyName("destinyMembershipId")]
    public long? DestinyMembershipId { get; set; }

    [JsonPropertyName("destinyMembershipType")]
    public int? DestinyMembershipType { get; set; }

    [JsonPropertyName("bungieNetMembershipId")]
    public long? BungieNetMembershipId { get; set; }

    [JsonPropertyName("bungieGlobalDisplayName")]
    public string BungieGlobalDisplayName { get; set; }

    [JsonPropertyName("bungieGlobalDisplayNameCode")]
    public short? BungieGlobalDisplayNameCode { get; set; }

    public bool DeepEquals(PlatformFriend? other)
    {
        return other is not null &&
               PlatformDisplayName == other.PlatformDisplayName &&
               FriendPlatform == other.FriendPlatform &&
               DestinyMembershipId == other.DestinyMembershipId &&
               DestinyMembershipType == other.DestinyMembershipType &&
               BungieNetMembershipId == other.BungieNetMembershipId &&
               BungieGlobalDisplayName == other.BungieGlobalDisplayName &&
               BungieGlobalDisplayNameCode == other.BungieGlobalDisplayNameCode;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(PlatformFriend? other)
    {
        if (other is null) return;
        if (PlatformDisplayName != other.PlatformDisplayName)
        {
            PlatformDisplayName = other.PlatformDisplayName;
            OnPropertyChanged(nameof(PlatformDisplayName));
        }
        if (FriendPlatform != other.FriendPlatform)
        {
            FriendPlatform = other.FriendPlatform;
            OnPropertyChanged(nameof(FriendPlatform));
        }
        if (DestinyMembershipId != other.DestinyMembershipId)
        {
            DestinyMembershipId = other.DestinyMembershipId;
            OnPropertyChanged(nameof(DestinyMembershipId));
        }
        if (DestinyMembershipType != other.DestinyMembershipType)
        {
            DestinyMembershipType = other.DestinyMembershipType;
            OnPropertyChanged(nameof(DestinyMembershipType));
        }
        if (BungieNetMembershipId != other.BungieNetMembershipId)
        {
            BungieNetMembershipId = other.BungieNetMembershipId;
            OnPropertyChanged(nameof(BungieNetMembershipId));
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
    }
}