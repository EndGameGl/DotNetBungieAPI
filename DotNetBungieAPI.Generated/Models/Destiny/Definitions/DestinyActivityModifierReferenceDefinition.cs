namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     A reference to an Activity Modifier from another entity, such as an Activity (for now, just Activities).
/// <para />
///     This defines some
/// </summary>
public class DestinyActivityModifierReferenceDefinition : IDeepEquatable<DestinyActivityModifierReferenceDefinition>
{
    /// <summary>
    ///     The hash identifier for the DestinyActivityModifierDefinition referenced by this activity.
    /// </summary>
    [JsonPropertyName("activityModifierHash")]
    public uint ActivityModifierHash { get; set; }

    public bool DeepEquals(DestinyActivityModifierReferenceDefinition? other)
    {
        return other is not null &&
               ActivityModifierHash == other.ActivityModifierHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityModifierReferenceDefinition? other)
    {
        if (other is null) return;
        if (ActivityModifierHash != other.ActivityModifierHash)
        {
            ActivityModifierHash = other.ActivityModifierHash;
            OnPropertyChanged(nameof(ActivityModifierHash));
        }
    }
}