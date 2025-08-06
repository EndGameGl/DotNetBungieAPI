namespace DotNetBungieAPI.Models.Destiny.Definitions;

[DestinyDefinition(DefinitionsEnum.DestinySandboxPatternDefinition)]
public sealed class DestinySandboxPatternDefinition : IDestinyDefinition
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinySandboxPatternDefinition;

    [JsonPropertyName("patternHash")]
    public uint PatternHash { get; init; }

    [JsonPropertyName("patternGlobalTagIdHash")]
    public uint PatternGlobalTagIdHash { get; init; }

    [JsonPropertyName("weaponContentGroupHash")]
    public uint WeaponContentGroupHash { get; init; }

    [JsonPropertyName("weaponTranslationGroupHash")]
    public uint WeaponTranslationGroupHash { get; init; }

    [JsonPropertyName("weaponTypeHash")]
    public uint? WeaponTypeHash { get; init; }

    [JsonPropertyName("weaponType")]
    public Destiny.DestinyItemSubType WeaponType { get; init; }

    [JsonPropertyName("filters")]
    public Destiny.Definitions.DestinyArrangementRegionFilterDefinition[]? Filters { get; init; }

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
