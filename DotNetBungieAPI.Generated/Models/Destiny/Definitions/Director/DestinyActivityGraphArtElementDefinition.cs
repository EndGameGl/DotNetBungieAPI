namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Director;

/// <summary>
///     These Art Elements are meant to represent one-off visual effects overlaid on the map. Currently, we do not have a pipeline to import the assets for these overlays, so this info exists as a placeholder for when such a pipeline exists (if it ever will)
/// </summary>
public class DestinyActivityGraphArtElementDefinition : IDeepEquatable<DestinyActivityGraphArtElementDefinition>
{
    /// <summary>
    ///     The position on the map of the art element.
    /// </summary>
    [JsonPropertyName("position")]
    public Destiny.Definitions.Common.DestinyPositionDefinition Position { get; set; }

    public bool DeepEquals(DestinyActivityGraphArtElementDefinition? other)
    {
        return other is not null &&
               (Position is not null ? Position.DeepEquals(other.Position) : other.Position is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyActivityGraphArtElementDefinition? other)
    {
        if (other is null) return;
        if (!Position.DeepEquals(other.Position))
        {
            Position.Update(other.Position);
            OnPropertyChanged(nameof(Position));
        }
    }
}