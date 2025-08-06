namespace DotNetBungieAPI.Models.Destiny.Definitions.Inventory;

/// <summary>
///     Lists of items that can be used for a variety of purposes, including featuring them as new gear
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyItemFilterDefinition)]
public sealed class DestinyItemFilterDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyItemFilterDefinition;

    /// <summary>
    ///     The items in this set
    /// </summary>
    [JsonPropertyName("allowedItems")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? AllowedItems { get; init; }

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
