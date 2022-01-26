namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyItemStateRequest : IDeepEquatable<DestinyItemStateRequest>
{
    [JsonPropertyName("state")]
    public bool State { get; set; }

    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyItemStateRequest? other)
    {
        return other is not null &&
               State == other.State &&
               ItemId == other.ItemId &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemStateRequest? other)
    {
        if (other is null) return;
        if (State != other.State)
        {
            State = other.State;
            OnPropertyChanged(nameof(State));
        }
        if (ItemId != other.ItemId)
        {
            ItemId = other.ItemId;
            OnPropertyChanged(nameof(ItemId));
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