namespace DotNetBungieAPI.Models;

public interface IDestinyDefinition
{
    /// <summary>
    ///     Enum value for this definition
    /// </summary>
    DefinitionsEnum DefinitionEnumValue { get; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    bool Redacted { get; init; }
}