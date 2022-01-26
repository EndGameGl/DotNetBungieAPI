namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     When a Graph needs to show active Progressions, this defines those objectives as well as an identifier.
/// </summary>
public class DestinyActivityGraphDisplayProgressionDefinition : IDeepEquatable<DestinyActivityGraphDisplayProgressionDefinition>
{
    [JsonPropertyName("id")]
    public uint Id { get; set; }

    [JsonPropertyName("progressionHash")]
    public uint ProgressionHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphDisplayProgressionDefinition? other)
    {
        return other is not null &&
               Id == other.Id &&
               ProgressionHash == other.ProgressionHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphDisplayProgressionDefinition? other)
    {
        if (other is null) return;
        if (Id != other.Id)
        {
            Id = other.Id;
            OnPropertyChanged(nameof(Id));
        }
        if (ProgressionHash != other.ProgressionHash)
        {
            ProgressionHash = other.ProgressionHash;
            OnPropertyChanged(nameof(ProgressionHash));
        }
    }
}