namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represents a status string that could be conditionally displayed about an activity. Note that externally, you can only see the strings themselves. Internally we combine this information with server state to determine which strings should be shown.
/// </summary>
public class DestinyActivityUnlockStringDefinition : IDeepEquatable<DestinyActivityUnlockStringDefinition>
{
    /// <summary>
    ///     The string to be displayed if the conditions are met.
    /// </summary>
    [JsonPropertyName("displayString")]
    public string DisplayString { get; set; }

    public bool DeepEquals(DestinyActivityUnlockStringDefinition? other)
    {
        return other is not null &&
               DisplayString == other.DisplayString;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityUnlockStringDefinition? other)
    {
        if (other is null) return;
        if (DisplayString != other.DisplayString)
        {
            DisplayString = other.DisplayString;
            OnPropertyChanged(nameof(DisplayString));
        }
    }
}