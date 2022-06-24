namespace DotNetBungieAPI.Models.Destiny;

/// <summary>
///     Base parameters for any destiny definition.
/// </summary>
public interface IDestinyDefinition
{
    /// <summary>
    ///     Enum value for this definition
    /// </summary>
    DefinitionsEnum DefinitionEnumValue { get; }

    /// <summary>
    ///     Whether this definition is blacklisted
    /// </summary>
    bool Blacklisted { get; init; }

    /// <summary>
    ///     Unique definition ID
    /// </summary>
    uint Hash { get; init; }

    int Index { get; init; }
    bool Redacted { get; init; }
}