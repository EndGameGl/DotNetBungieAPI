namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Represent a set of material requirements: Items that either need to be owned or need to be consumed in order to perform an action.
/// <para />
///     A variety of other entities refer to these as gatekeepers and payments for actions that can be performed in game.
/// </summary>
public class DestinyMaterialRequirementSetDefinition : IDeepEquatable<DestinyMaterialRequirementSetDefinition>
{
    /// <summary>
    ///     The list of all materials that are required.
    /// </summary>
    [JsonPropertyName("materials")]
    public List<Destiny.Definitions.DestinyMaterialRequirement> Materials { get; set; }

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

    public bool DeepEquals(DestinyMaterialRequirementSetDefinition? other)
    {
        return other is not null &&
               Materials.DeepEqualsList(other.Materials) &&
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

    public void Update(DestinyMaterialRequirementSetDefinition? other)
    {
        if (other is null) return;
        if (!Materials.DeepEqualsList(other.Materials))
        {
            Materials = other.Materials;
            OnPropertyChanged(nameof(Materials));
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