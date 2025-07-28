namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Social;

public class DestinySocialCommendationNodeDefinition : IDestinyDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    /// <summary>
    ///     The color associated with this group of commendations.
    /// </summary>
    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; set; }

    /// <summary>
    ///     A version of the displayProperties icon tinted with the color of this node.
    /// </summary>
    [JsonPropertyName("tintedIcon")]
    public string TintedIcon { get; set; }

    [Destiny2Definition<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition>("Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition")]
    [JsonPropertyName("parentCommendationNodeHash")]
    public uint ParentCommendationNodeHash { get; set; }

    /// <summary>
    ///     A list of hashes that map to child commendation nodes. Only the root commendations node is expected to have child nodes.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition>("Destiny.Definitions.Social.DestinySocialCommendationNodeDefinition")]
    [JsonPropertyName("childCommendationNodeHashes")]
    public uint[]? ChildCommendationNodeHashes { get; set; }

    /// <summary>
    ///     A list of hashes that map to child commendations.
    /// </summary>
    [Destiny2Definition<Destiny.Definitions.Social.DestinySocialCommendationDefinition>("Destiny.Definitions.Social.DestinySocialCommendationDefinition")]
    [JsonPropertyName("childCommendationHashes")]
    public uint[]? ChildCommendationHashes { get; set; }

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
}
