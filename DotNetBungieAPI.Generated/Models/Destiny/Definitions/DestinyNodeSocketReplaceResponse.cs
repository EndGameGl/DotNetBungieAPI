namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     This is a bit of an odd duck. Apparently, if talent nodes steps have this data, the game will go through on step activation and alter the first Socket it finds on the item that has a type matching the given socket type, inserting the indicated plug item.
/// </summary>
public class DestinyNodeSocketReplaceResponse : IDeepEquatable<DestinyNodeSocketReplaceResponse>
{
    /// <summary>
    ///     The hash identifier of the socket type to find amidst the item's sockets (the item to which this talent grid is attached). See DestinyInventoryItemDefinition.sockets.socketEntries to find the socket type of sockets on the item in question.
    /// </summary>
    [JsonPropertyName("socketTypeHash")]
    public uint SocketTypeHash { get; set; }

    /// <summary>
    ///     The hash identifier of the plug item that will be inserted into the socket found.
    /// </summary>
    [JsonPropertyName("plugItemHash")]
    public uint PlugItemHash { get; set; }

    public bool DeepEquals(DestinyNodeSocketReplaceResponse? other)
    {
        return other is not null &&
               SocketTypeHash == other.SocketTypeHash &&
               PlugItemHash == other.PlugItemHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyNodeSocketReplaceResponse? other)
    {
        if (other is null) return;
        if (SocketTypeHash != other.SocketTypeHash)
        {
            SocketTypeHash = other.SocketTypeHash;
            OnPropertyChanged(nameof(SocketTypeHash));
        }
        if (PlugItemHash != other.PlugItemHash)
        {
            PlugItemHash = other.PlugItemHash;
            OnPropertyChanged(nameof(PlugItemHash));
        }
    }
}