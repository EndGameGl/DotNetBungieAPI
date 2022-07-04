using DotNetBungieAPI.Models.Attributes;

namespace DotNetBungieAPI.Service.Abstractions.AssemblyData;

public class DefinitionUseRule
{
    public DestinyDefinitionAttribute AttributeData { get; }
    public Type DefinitionType { get; }

    public DefinitionUseRule(
        DestinyDefinitionAttribute attributeData,
        Type definitionType)
    {
        AttributeData = attributeData;
        DefinitionType = definitionType;
    }
}