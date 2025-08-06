namespace DotNetBungieAPI.Models.Destiny.Definitions.Social;

[DestinyDefinition(DefinitionsEnum.DestinySocialCommendationNodeDefinition)]
public sealed class DestinySocialCommendationNodeDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySocialCommendationNodeDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    /// <summary>
    ///     The color associated with this group of commendations.
    /// </summary>
    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; init; }

    /// <summary>
    ///     A version of the displayProperties icon tinted with the color of this node.
    /// </summary>
    [JsonPropertyName("tintedIcon")]
    public string TintedIcon { get; init; }

    [JsonPropertyName("parentCommendationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition> ParentCommendationNodeHash { get; init; }

    /// <summary>
    ///     A list of hashes that map to child commendation nodes. Only the root commendations node is expected to have child nodes.
    /// </summary>
    [JsonPropertyName("childCommendationNodeHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition>[]? ChildCommendationNodeHashes { get; init; }

    /// <summary>
    ///     A list of hashes that map to child commendations.
    /// </summary>
    [JsonPropertyName("childCommendationHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Social.DestinySocialCommendationDefinition>[]? ChildCommendationHashes { get; init; }

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
