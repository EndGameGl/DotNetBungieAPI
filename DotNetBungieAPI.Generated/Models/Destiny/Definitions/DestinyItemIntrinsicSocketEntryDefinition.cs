namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represents a socket that has a plug associated with it intrinsically. This is useful for situations where the weapon needs to have a visual plug/Mod on it, but that plug/Mod should never change.
/// </summary>
public class DestinyItemIntrinsicSocketEntryDefinition : IDeepEquatable<DestinyItemIntrinsicSocketEntryDefinition>
{
    /// <summary>
    ///     Indicates the plug that is intrinsically inserted into this socket.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    /// <summary>
    ///     Indicates the type of this intrinsic socket.
    /// </summary>
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    /// <summary>
    ///     If true, then this socket is visible in the item's "default" state. If you have an instance, you should always check the runtime state, as that can override this visibility setting: but if you're looking at the item on a conceptual level, this property can be useful for hiding data such as legacy sockets - which remain defined on items for infrastructure purposes, but can be confusing for users to see.
    /// </summary>
    [JsonPropertyName("defaultVisible")]
    public bool DefaultVisible { get; set; }

    public bool DeepEquals(DestinyItemIntrinsicSocketEntryDefinition? other)
    {
        return other is not null &&
               PlugItemHash == other.PlugItemHash &&
               SocketTypeHash == other.SocketTypeHash &&
               DefaultVisible == other.DefaultVisible;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemIntrinsicSocketEntryDefinition? other)
    {
        if (other is null) return;
        if (PlugItemHash != other.PlugItemHash)
        {
            PlugItemHash = other.PlugItemHash;
            OnPropertyChanged(nameof(PlugItemHash));
        }
        if (SocketTypeHash != other.SocketTypeHash)
        {
            SocketTypeHash = other.SocketTypeHash;
            OnPropertyChanged(nameof(SocketTypeHash));
        }
        if (DefaultVisible != other.DefaultVisible)
        {
            DefaultVisible = other.DefaultVisible;
            OnPropertyChanged(nameof(DefaultVisible));
        }
    }
}