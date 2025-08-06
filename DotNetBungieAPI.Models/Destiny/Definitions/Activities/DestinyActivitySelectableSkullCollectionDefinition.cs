namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

[DestinyDefinition(DefinitionsEnum.DestinyActivitySelectableSkullCollectionDefinition)]
public sealed class DestinyActivitySelectableSkullCollectionDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivitySelectableSkullCollectionDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("skullSubcategoryHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySkullSubcategoryDefinition>[]? SkullSubcategoryHashes { get; init; }

    [JsonPropertyName("selectionType")]
    public Destiny.Definitions.Activities.DestinyActivitySelectableSkullCollectionSelectionType? SelectionType { get; init; }

    [JsonPropertyName("selectableActivitySkulls")]
    public Destiny.Definitions.Activities.DestinyActivitySelectableSkull[]? SelectableActivitySkulls { get; init; }

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
