using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Collectibles;

/// <summary>
///     Defines a
/// </summary>
public sealed class DestinyCollectibleDefinition
{

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     Indicates whether the state of this Collectible is determined on a per-character or on an account-wide basis.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; init; }

    /// <summary>
    ///     A human readable string for a hint about how to acquire the item.
    /// </summary>
    [JsonPropertyName("sourceString")]
    public string SourceString { get; init; }

    /// <summary>
    ///     This is a hash identifier we are building on the BNet side in an attempt to let people group collectibles by similar sources.
    /// <para />
    ///     I can't promise that it's going to be 100% accurate, but if the designers were consistent in assigning the same source strings to items with the same sources, it *ought to* be. No promises though.
    /// <para />
    ///     This hash also doesn't relate to an actual definition, just to note: we've got nothing useful other than the source string for this data.
    /// </summary>
    [JsonPropertyName("sourceHash")]
    public uint? SourceHash { get; init; }

    [JsonPropertyName("itemHash")]
    public uint ItemHash { get; init; }

    [JsonPropertyName("acquisitionInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleAcquisitionBlock AcquisitionInfo { get; init; }

    [JsonPropertyName("stateInfo")]
    public Destiny.Definitions.Collectibles.DestinyCollectibleStateBlock StateInfo { get; init; }

    [JsonPropertyName("presentationInfo")]
    public Destiny.Definitions.Presentation.DestinyPresentationChildBlock PresentationInfo { get; init; }

    [JsonPropertyName("presentationNodeType")]
    public Destiny.DestinyPresentationNodeType PresentationNodeType { get; init; }

    [JsonPropertyName("traitIds")]
    public List<string> TraitIds { get; init; }

    [JsonPropertyName("traitHashes")]
    public List<uint> TraitHashes { get; init; }

    /// <summary>
    ///     A quick reference to presentation nodes that have this node as a child. Presentation nodes can be parented under multiple parents.
    /// </summary>
    [JsonPropertyName("parentNodeHashes")]
    public List<uint> ParentNodeHashes { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
