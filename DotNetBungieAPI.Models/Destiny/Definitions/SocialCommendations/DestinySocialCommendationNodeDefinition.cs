using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;

namespace DotNetBungieAPI.Models.Destiny.Definitions.SocialCommendations;

[DestinyDefinition(DefinitionsEnum.DestinySocialCommendationNodeDefinition)]
public sealed record DestinySocialCommendationNodeDefinition : IDestinyDefinition, IDisplayProperties, IDeepEquatable<DestinySocialCommendationNodeDefinition>
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySocialCommendationNodeDefinition;

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The color associated with this group of commendations.
    /// </summary>
    [JsonPropertyName("color")]
    public DestinyColor Color { get; init; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public DefinitionHashPointer<DestinySocialCommendationNodeDefinition> ParentCommendationNode { get; init; }
        = DefinitionHashPointer<DestinySocialCommendationNodeDefinition>.Empty;

    /// <summary>
    ///     A list of hashes that map to child commendation nodes. Only the root commendations node is expected to have child nodes.
    /// </summary>
    [JsonPropertyName("childCommendationNodeHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinySocialCommendationNodeDefinition>> ChildCommendationNodes { get; init; }
        = ReadOnlyCollections<DefinitionHashPointer<DestinySocialCommendationNodeDefinition>>.Empty;

    /// <summary>
    ///     A list of hashes that map to child commendations.
    /// </summary>
    [JsonPropertyName("childCommendationHashes")]
    public ReadOnlyCollection<DefinitionHashPointer<DestinySocialCommendationDefinition>> ChildCommendations { get; init; }
        = ReadOnlyCollections<DefinitionHashPointer<DestinySocialCommendationDefinition>>.Empty;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    public bool DeepEquals(DestinySocialCommendationNodeDefinition other)
    {
        return other is not null &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               Color.DeepEquals(other.Color) &&
               ParentCommendationNode.DeepEquals(other.ParentCommendationNode) &&
               ChildCommendationNodes.DeepEqualsReadOnlyCollections(other.ChildCommendationNodes) &&
               ChildCommendations.DeepEqualsReadOnlyCollections(other.ChildCommendations) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }
}
