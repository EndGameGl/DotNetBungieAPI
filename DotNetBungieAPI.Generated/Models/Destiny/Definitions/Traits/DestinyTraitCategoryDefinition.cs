namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Traits;

public class DestinyTraitCategoryDefinition : IDeepEquatable<DestinyTraitCategoryDefinition>
{
    [JsonPropertyName("traitCategoryId")]
    public string TraitCategoryId { get; set; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

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

    public bool DeepEquals(DestinyTraitCategoryDefinition? other)
    {
        return other is not null &&
               TraitCategoryId == other.TraitCategoryId &&
               TraitHashes.DeepEqualsListNaive(other.TraitHashes) &&
               TraitIds.DeepEqualsListNaive(other.TraitIds) &&
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

    public void Update(DestinyTraitCategoryDefinition? other)
    {
        if (other is null) return;
        if (TraitCategoryId != other.TraitCategoryId)
        {
            TraitCategoryId = other.TraitCategoryId;
            OnPropertyChanged(nameof(TraitCategoryId));
        }
        if (!TraitHashes.DeepEqualsListNaive(other.TraitHashes))
        {
            TraitHashes = other.TraitHashes;
            OnPropertyChanged(nameof(TraitHashes));
        }
        if (!TraitIds.DeepEqualsListNaive(other.TraitIds))
        {
            TraitIds = other.TraitIds;
            OnPropertyChanged(nameof(TraitIds));
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