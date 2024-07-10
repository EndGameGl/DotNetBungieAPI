using System.Reflection;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.AssemblyData;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefinitionAssemblyData : IDefinitionAssemblyData
{
    public DefinitionAssemblyData()
    {
        var tempDefinitionsToTypeMapping = new Dictionary<DefinitionsEnum, DefinitionUseRule>();
        var tempTypeToEnumMapping = new Dictionary<Type, DefinitionsEnum>();
        var mappedTypes = Assembly
            .GetAssembly(typeof(DefinitionHashPointer<>))!
            .GetTypes()
            .Where(x => x.GetCustomAttributes<DestinyDefinitionAttribute>().Any());

        foreach (var type in mappedTypes)
        {
            var definitionAttribute = type.GetCustomAttribute<DestinyDefinitionAttribute>();
            var enumValue = definitionAttribute!.DefinitionEnumType;
            var useRule = new DefinitionUseRule(definitionAttribute, type);
            tempDefinitionsToTypeMapping.Add(enumValue, useRule);
            tempTypeToEnumMapping.Add(useRule.DefinitionType, enumValue);
        }

        DefinitionsToTypeMapping = new ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule>(
            tempDefinitionsToTypeMapping
        );
        TypeToEnumMapping = new ReadOnlyDictionary<Type, DefinitionsEnum>(tempTypeToEnumMapping);
    }

    public ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
    public ReadOnlyDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
}
