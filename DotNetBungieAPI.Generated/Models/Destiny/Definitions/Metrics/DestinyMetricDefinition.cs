namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Metrics;

public class DestinyMetricDefinition : IDeepEquatable<DestinyMetricDefinition>
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("trackingObjectiveHash")]
    public uint TrackingObjectiveHash { get; set; }

    [JsonPropertyName("lowerValueIsBetter")]
    public bool LowerValueIsBetter { get; set; }

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

    public bool DeepEquals(DestinyMetricDefinition? other)
    {
        return other is not null &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               TrackingObjectiveHash == other.TrackingObjectiveHash &&
               LowerValueIsBetter == other.LowerValueIsBetter &&
               PresentationNodeType == other.PresentationNodeType &&
               TraitIds.DeepEqualsListNaive(other.TraitIds) &&
               TraitHashes.DeepEqualsListNaive(other.TraitHashes) &&
               ParentNodeHashes.DeepEqualsListNaive(other.ParentNodeHashes) &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}