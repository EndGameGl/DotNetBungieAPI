namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemSetActionRequest : IDeepEquatable<DestinyItemSetActionRequest>
{
    [JsonPropertyName("itemIds")]
    public List<long> ItemIds { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyItemSetActionRequest? other)
    {
        return other is not null &&
               ItemIds.DeepEqualsListNaive(other.ItemIds) &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSetActionRequest? other)
    {
        if (other is null) return;
        if (!ItemIds.DeepEqualsListNaive(other.ItemIds))
        {
            ItemIds = other.ItemIds;
            OnPropertyChanged(nameof(ItemIds));
        }
        if (CharacterId != other.CharacterId)
        {
            CharacterId = other.CharacterId;
            OnPropertyChanged(nameof(CharacterId));
        }
        if (MembershipType != other.MembershipType)
        {
            MembershipType = other.MembershipType;
            OnPropertyChanged(nameof(MembershipType));
        }
    }
}