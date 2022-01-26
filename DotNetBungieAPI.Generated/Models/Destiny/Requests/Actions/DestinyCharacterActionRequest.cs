namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyCharacterActionRequest : IDeepEquatable<DestinyCharacterActionRequest>
{
    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyCharacterActionRequest? other)
    {
        return other is not null &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCharacterActionRequest? other)
    {
        if (other is null) return;
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