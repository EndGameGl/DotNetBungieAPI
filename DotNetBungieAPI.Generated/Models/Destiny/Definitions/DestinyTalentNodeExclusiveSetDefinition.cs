namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     The list of indexes into the Talent Grid's "nodes" property for nodes in this exclusive set. (See DestinyTalentNodeDefinition.nodeIndex)
/// </summary>
public class DestinyTalentNodeExclusiveSetDefinition : IDeepEquatable<DestinyTalentNodeExclusiveSetDefinition>
{
    /// <summary>
    ///     The list of node indexes for the exclusive set. Historically, these were indexes. I would have liked to replace this with nodeHashes for consistency, but it's way too late for that. (9:09 PM, he's right!)
    /// </summary>
    [JsonPropertyName("nodeIndexes")]
    public List<int> NodeIndexes { get; set; }

    public bool DeepEquals(DestinyTalentNodeExclusiveSetDefinition? other)
    {
        return other is not null &&
               NodeIndexes.DeepEqualsListNaive(other.NodeIndexes);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyTalentNodeExclusiveSetDefinition? other)
    {
        if (other is null) return;
        if (!NodeIndexes.DeepEqualsListNaive(other.NodeIndexes))
        {
            NodeIndexes = other.NodeIndexes;
            OnPropertyChanged(nameof(NodeIndexes));
        }
    }
}