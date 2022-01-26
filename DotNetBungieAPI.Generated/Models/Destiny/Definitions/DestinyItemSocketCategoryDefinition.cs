namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Sockets are grouped into categories in the UI. These define which category and which sockets are under that category.
/// </summary>
public class DestinyItemSocketCategoryDefinition : IDeepEquatable<DestinyItemSocketCategoryDefinition>
{
    /// <summary>
    ///     The hash for the Socket Category: a quick way to go get the header display information for the category. Use it to look up DestinySocketCategoryDefinition info.
    /// </summary>
    [JsonPropertyName("socketCategoryHash")]
    public uint SocketCategoryHash { get; set; }

    /// <summary>
    ///     Use these indexes to look up the sockets in the "sockets.socketEntries" property on the item definition. These are the indexes under the category, in game-rendered order.
    /// </summary>
    [JsonPropertyName("socketIndexes")]
    public List<int> SocketIndexes { get; set; }

    public bool DeepEquals(DestinyItemSocketCategoryDefinition? other)
    {
        return other is not null &&
               SocketCategoryHash == other.SocketCategoryHash &&
               SocketIndexes.DeepEqualsListNaive(other.SocketIndexes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSocketCategoryDefinition? other)
    {
        if (other is null) return;
        if (SocketCategoryHash != other.SocketCategoryHash)
        {
            SocketCategoryHash = other.SocketCategoryHash;
            OnPropertyChanged(nameof(SocketCategoryHash));
        }
        if (!SocketIndexes.DeepEqualsListNaive(other.SocketIndexes))
        {
            SocketIndexes = other.SocketIndexes;
            OnPropertyChanged(nameof(SocketIndexes));
        }
    }
}