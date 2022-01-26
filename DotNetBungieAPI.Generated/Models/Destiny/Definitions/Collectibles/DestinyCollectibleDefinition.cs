namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

/// <summary>
///     Defines a
/// </summary>
public class DestinyCollectibleDefinition : IDeepEquatable<DestinyCollectibleDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    /// <summary>
    ///     Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    /// <summary>
    ///     A human readable string for a hint about how to acquire the item.
    /// </summary>
    [JsonPropertyName("sourceString")]
    public string SourceString { get; set; }

    /// <summary>
    ///     This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by similar sources.
    /// <para />
    ///     I can't promise that it's going to be 100% accurate, but if the designers were consistent in assigning the same source strings to items with the same sources, it *ought to* be. No promises though.
    /// <para />
    ///     This hash also doesn't relate to an actual definition, just to note: we've got nothing useful other than the source string for this data.
    /// </summary>
    [JsonPropertyName("sourceHash")]
    public uint? SourceHash { get; set; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; set; }

    [JsonPropertyName("acquisitionInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleAcquisitionBlock AcquisitionInfo { get; set; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleStateBlock StateInfo { get; set; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; set; }

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

    public bool DeepEquals(DestinyCollectibleDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               Scope == other.Scope &&
               SourceString == other.SourceString &&
               SourceHash == other.SourceHash &&
               ItemHash == other.ItemHash &&
               (AcquisitionInfo is not null ? AcquisitionInfo.DeepEquals(other.AcquisitionInfo) : other.AcquisitionInfo is null) &&
               (StateInfo is not null ? StateInfo.DeepEquals(other.StateInfo) : other.StateInfo is null) &&
               (PresentationInfo is not null ? PresentationInfo.DeepEquals(other.PresentationInfo) : other.PresentationInfo is null) &&
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

    public void Update(DestinyCollectibleDefinition? other)
    {
        if (other is null) return;
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (Scope != other.Scope)
        {
            Scope = other.Scope;
            OnPropertyChanged(nameof(Scope));
        }
        if (SourceString != other.SourceString)
        {
            SourceString = other.SourceString;
            OnPropertyChanged(nameof(SourceString));
        }
        if (SourceHash != other.SourceHash)
        {
            SourceHash = other.SourceHash;
            OnPropertyChanged(nameof(SourceHash));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (!AcquisitionInfo.DeepEquals(other.AcquisitionInfo))
        {
            AcquisitionInfo.Update(other.AcquisitionInfo);
            OnPropertyChanged(nameof(AcquisitionInfo));
        }
        if (!StateInfo.DeepEquals(other.StateInfo))
        {
            StateInfo.Update(other.StateInfo);
            OnPropertyChanged(nameof(StateInfo));
        }
        if (!PresentationInfo.DeepEquals(other.PresentationInfo))
        {
            PresentationInfo.Update(other.PresentationInfo);
            OnPropertyChanged(nameof(PresentationInfo));
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