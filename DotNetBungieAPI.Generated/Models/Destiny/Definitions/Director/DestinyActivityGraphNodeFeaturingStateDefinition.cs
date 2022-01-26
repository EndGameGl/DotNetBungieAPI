namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     Nodes can have different visual states. This object represents a single visual state ("highlight type") that a node can be in, and the unlock expression condition to determine whether it should be set.
/// </summary>
public class DestinyActivityGraphNodeFeaturingStateDefinition : IDeepEquatable<DestinyActivityGraphNodeFeaturingStateDefinition>
{
    /// <summary>
    ///     The node can be highlighted in a variety of ways - the game iterates through these and finds the first FeaturingState that is valid at the present moment given the Game, Account, and Character state, and renders the node in that state. See the ActivityGraphNodeHighlightType enum for possible values.
    /// </summary>
    [JsonPropertyName("highlightType")]
    public Destiny.ActivityGraphNodeHighlightType HighlightType { get; set; }

    public bool DeepEquals(DestinyActivityGraphNodeFeaturingStateDefinition? other)
    {
        return other is not null &&
               HighlightType == other.HighlightType;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphNodeFeaturingStateDefinition? other)
    {
        if (other is null) return;
        if (HighlightType != other.HighlightType)
        {
            HighlightType = other.HighlightType;
            OnPropertyChanged(nameof(HighlightType));
        }
    }
}