using System.Collections.Frozen;
using System.Reflection;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Service.Abstractions;
using DotNetBungieAPI.Service.Abstractions.AssemblyData;

namespace DotNetBungieAPI.Services.Implementations;

internal sealed class DefinitionAssemblyData : IDefinitionAssemblyData
{
    public FrozenDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
    public FrozenDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }

    public DefinitionAssemblyData()
    {
        var tempDefinitionsToTypeMapping = new Dictionary<DefinitionsEnum, DefinitionUseRule>();
        var tempTypeToEnumMapping = new Dictionary<Type, DefinitionsEnum>();
        var mappedTypes = Assembly.GetAssembly(typeof(DefinitionHashPointer<>))!.GetTypes().Where(x => x.GetCustomAttributes<DestinyDefinitionAttribute>().Any());

        foreach (var type in mappedTypes)
        {
            var definitionAttribute = type.GetCustomAttribute<DestinyDefinitionAttribute>();
            var enumValue = definitionAttribute!.DefinitionEnumType;
            var useRule = new DefinitionUseRule(definitionAttribute, type);
            tempDefinitionsToTypeMapping.Add(enumValue, useRule);
            tempTypeToEnumMapping.Add(useRule.DefinitionType, enumValue);
        }

        DefinitionsToTypeMapping = tempDefinitionsToTypeMapping.ToFrozenDictionary();
        TypeToEnumMapping = tempTypeToEnumMapping.ToFrozenDictionary();
    }
}
