namespace DotNetBungieAPI.Models.Destiny.Definitions.ActivityModifiers;

/// <summary>
///     Modifiers - in Destiny 1, these were referred to as "Skulls" - are changes that can be applied to an Activity.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyActivityModifierDefinition)]
public sealed class DestinyActivityModifierDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyActivityModifierDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("displayInNavMode")]
    public bool DisplayInNavMode { get; init; }

    [JsonPropertyName("displayInActivitySelection")]
    public bool DisplayInActivitySelection { get; init; }

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
