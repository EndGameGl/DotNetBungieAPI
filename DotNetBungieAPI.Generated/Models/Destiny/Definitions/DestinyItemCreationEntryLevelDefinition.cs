namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An overly complicated wrapper for the item level at which the item should spawn.
/// </summary>
public class DestinyItemCreationEntryLevelDefinition : IDeepEquatable<DestinyItemCreationEntryLevelDefinition>
{
    [JsonPropertyName("level")]
    public int Level { get; set; }

    public bool DeepEquals(DestinyItemCreationEntryLevelDefinition? other)
    {
        return other is not null &&
               Level == other.Level;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemCreationEntryLevelDefinition? other)
    {
        if (other is null) return;
        if (Level != other.Level)
        {
            Level = other.Level;
            OnPropertyChanged(nameof(Level));
        }
    }
}