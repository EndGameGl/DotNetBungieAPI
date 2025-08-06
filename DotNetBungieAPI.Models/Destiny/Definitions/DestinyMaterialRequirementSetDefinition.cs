namespace DotNetBungieAPI.Models.Destiny.Definitions;

/// <summary>
///     Represent a set of material requirements: Items that either need to be owned or need to be consumed in order to perform an action.
/// <para />
///     A variety of other entities refer to these as gatekeepers and payments for actions that can be performed in game.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyMaterialRequirementSetDefinition)]
public sealed class DestinyMaterialRequirementSetDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyMaterialRequirementSetDefinition;

    /// <summary>
    ///     The list of all materials that are required.
    /// </summary>
    [JsonPropertyName("materials")]
    public Destiny.Definitions.DestinyMaterialRequirement[]? Materials { get; init; }

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
