namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Okay, so Activities (DestinyActivityDefinition) take place in Destinations (DestinyDestinationDefinition). Destinations are part of larger locations known as Places (you're reading its documentation right now).
/// <para />
///     Places are more on the planetary scale, like "Earth" and "Your Mom."
/// </summary>
public class DestinyPlaceDefinition : IDeepEquatable<DestinyPlaceDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyPlaceDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyPlaceDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}