namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Destinations and Activities may have default Activity Graphs that should be shown when you bring up the Director and are playing in either.
/// <para />
///     This contract defines the graph referred to and the gating for when it is relevant.
/// </summary>
public class DestinyActivityGraphListEntryDefinition : IDeepEquatable<DestinyActivityGraphListEntryDefinition>
{
    /// <summary>
    ///     The hash identifier of the DestinyActivityGraphDefinition that should be shown when opening the director.
    /// </summary>
    [JsonPropertyName("activityGraphHash")]
    public uint ActivityGraphHash { get; set; }

    public bool DeepEquals(DestinyActivityGraphListEntryDefinition? other)
    {
        return other is not null &&
               ActivityGraphHash == other.ActivityGraphHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphListEntryDefinition? other)
    {
        if (other is null) return;
        if (ActivityGraphHash != other.ActivityGraphHash)
        {
            ActivityGraphHash = other.ActivityGraphHash;
            OnPropertyChanged(nameof(ActivityGraphHash));
        }
    }
}