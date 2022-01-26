namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Nodes on a graph can be visually connected: this appears to be the information about which nodes to link. It appears to lack more detailed information, such as the path for that linking.
/// </summary>
public class DestinyActivityGraphConnectionDefinition : IDeepEquatable<DestinyActivityGraphConnectionDefinition>
{
    [JsonPropertyName("sourceNodeHash")]
    public uint SourceNodeHash { get; set; }

    [JsonPropertyName("destNodeHash")]
    public uint DestNodeHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphConnectionDefinition? other)
    {
        return other is not null &&
               SourceNodeHash == other.SourceNodeHash &&
               DestNodeHash == other.DestNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphConnectionDefinition? other)
    {
        if (other is null) return;
        if (SourceNodeHash != other.SourceNodeHash)
        {
            SourceNodeHash = other.SourceNodeHash;
            OnPropertyChanged(nameof(SourceNodeHash));
        }
        if (DestNodeHash != other.DestNodeHash)
        {
            DestNodeHash = other.DestNodeHash;
            OnPropertyChanged(nameof(DestNodeHash));
        }
    }
}