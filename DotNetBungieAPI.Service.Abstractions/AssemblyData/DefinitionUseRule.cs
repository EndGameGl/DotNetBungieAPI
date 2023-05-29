using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Service.Abstractions.AssemblyData;

/// <summary>
///     Rules that define whether definition is disabled manually within library
/// </summary>
public class DefinitionUseRule
{
    /// <summary>
    ///     Attribute data
    /// </summary>
    public DestinyDefinitionAttribute AttributeData { get; }

    /// <summary>
    ///     Definition type
    /// </summary>
    public Type DefinitionType { get; }

    /// <summary>
    ///     .ctor
    /// </summary>
    /// <param name="attributeData"></param>
    /// <param name="definitionType"></param>
    public DefinitionUseRule(DestinyDefinitionAttribute attributeData, Type definitionType)
    {
        AttributeData = attributeData;
        DefinitionType = definitionType;
    }
}
