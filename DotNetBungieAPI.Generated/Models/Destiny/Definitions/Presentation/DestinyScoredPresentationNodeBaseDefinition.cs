namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Presentation;

public class DestinyScoredPresentationNodeBaseDefinition : IDeepEquatable<DestinyScoredPresentationNodeBaseDefinition>
{
    [JsonPropertyName("maxCategoryRecordScore")]
    public int MaxCategoryRecordScore { get; set; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; set; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; set; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; set; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; set; }

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

    public bool DeepEquals(DestinyScoredPresentationNodeBaseDefinition? other)
    {
        return other is not null &&
               MaxCategoryRecordScore == other.MaxCategoryRecordScore &&
               PresentationNodeType == other.PresentationNodeType &&
               TraitIds.DeepEqualsListNaive(other.TraitIds) &&
               TraitHashes.DeepEqualsListNaive(other.TraitHashes) &&
               ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes) &&
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

    public void Update(DestinyScoredPresentationNodeBaseDefinition? other)
    {
        if (other is null) return;
        if (MaxCategoryRecordScore != other.MaxCategoryRecordScore)
        {
            MaxCategoryRecordScore = other.MaxCategoryRecordScore;
            OnPropertyChanged(nameof(MaxCategoryRecordScore));
        }
        if (PresentationNodeType != other.PresentationNodeType)
        {
            PresentationNodeType = other.PresentationNodeType;
            OnPropertyChanged(nameof(PresentationNodeType));
        }
        if (!TraitIds.DeepEqualsListNaive(other.TraitIds))
        {
            TraitIds = other.TraitIds;
            OnPropertyChanged(nameof(TraitIds));
        }
        if (!TraitHashes.DeepEqualsListNaive(other.TraitHashes))
        {
            TraitHashes = other.TraitHashes;
            OnPropertyChanged(nameof(TraitHashes));
        }
        if (!ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes))
        {
            ParentNodeHashes = other.ParentNodeHashes;
            OnPropertyChanged(nameof(ParentNodeHashes));
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