namespace DotNetBungieAPI.Generated.Models.Destiny.Requests.Actions;

public class DestinyInsertPlugsActionRequest : IDeepEquatable<DestinyInsertPlugsActionRequest>
{
    /// <summary>
    ///     Action token provided by the AwaGetActionToken API call.
    /// </summary>
    [JsonPropertyName("actionToken")]
    public string ActionToken { get; set; }

    /// <summary>
    ///     The instance ID of the item having a plug inserted. Only instanced items can have sockets.
    /// </summary>
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; set; }

    /// <summary>
    ///     The plugs being inserted.
    /// </summary>
    [JsonPropertyName("plug")]
    public Destiny.Requests.Actions.DestinyInsertPlugsRequestEntry Plug { get; set; }

    [JsonPropertyName("characterId")]
    public long CharacterId { get; set; }

    [JsonPropertyName("membershipType")]
    public BungieMembershipType MembershipType { get; set; }

    public bool DeepEquals(DestinyInsertPlugsActionRequest? other)
    {
        return other is not null &&
               ActionToken == other.ActionToken &&
               ItemInstanceId == other.ItemInstanceId &&
               (Plug is not null ? Plug.DeepEquals(other.Plug) : other.Plug is null) &&
               CharacterId == other.CharacterId &&
               MembershipType == other.MembershipType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyInsertPlugsActionRequest? other)
    {
        if (other is null) return;
        if (ActionToken != other.ActionToken)
        {
            ActionToken = other.ActionToken;
            OnPropertyChanged(nameof(ActionToken));
        }
        if (ItemInstanceId != other.ItemInstanceId)
        {
            ItemInstanceId = other.ItemInstanceId;
            OnPropertyChanged(nameof(ItemInstanceId));
        }
        if (!Plug.DeepEquals(other.Plug))
        {
            Plug.Update(other.Plug);
            OnPropertyChanged(nameof(Plug));
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