namespace DotNetBungieAPI.Models.Destiny.Definitions.Activities;

[DestinyDefinition(DefinitionsEnum.DestinyActivityFamilyDefinition)]
public sealed class DestinyActivityFamilyDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityFamilyDefinition;

    [JsonPropertyName("traits")]
    public DefinitionHashPointer<Destiny.Definitions.Traits.DestinyTraitDefinition>[]? Traits { get; init; }

    [JsonPropertyName("disabledSkullCategoryHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySkullCategoryDefinition>[]? DisabledSkullCategoryHashes { get; init; }

    [JsonPropertyName("disabledSkullSubcategoryHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySkullSubcategoryDefinition>[]? DisabledSkullSubcategoryHashes { get; init; }

    [JsonPropertyName("fixedSkullSubcategoryHashes")]
    public DefinitionHashPointer<Destiny.Definitions.Activities.DestinyActivitySkullSubcategoryDefinition>[]? FixedSkullSubcategoryHashes { get; init; }

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
