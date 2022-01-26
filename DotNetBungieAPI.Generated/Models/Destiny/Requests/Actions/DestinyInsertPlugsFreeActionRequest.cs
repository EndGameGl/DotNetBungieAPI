namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyInsertPlugsFreeActionRequest : IDeepEquatable<DestinyInsertPlugsFreeActionRequest>
{
    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; set; }

    /// <summary>
    ///     The instance ID of the item for this action request.
    /// </summary>
    [JsonPropertyName("itemId")]
    public long ItemId { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyInsertPlugsFreeActionRequest? other)
    {
        return other is not null &&
               (Plug is not null ? Plug.DeepEquals(other.Plug) : other.Plug is null) &&
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

    public void Update(DestinyInsertPlugsFreeActionRequest? other)
    {
        if (other is null) return;
        if (!Plug.DeepEquals(other.Plug))
        {
            Plug.Update(other.Plug);
            OnPropertyChanged(nameof(Plug));
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