using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Repositories;
using DotNetBungieAPI.Services.Interfaces;

namespace DotNetBungieAPI.Services
{
    internal sealed class DefinitionAssemblyData : IDefinitionAssemblyData
    {
        internal DefinitionAssemblyData()
        {
            var tempDefinitionsToTypeMapping = new Dictionary<DefinitionsEnum, DefinitionUseRule>();
            var tempTypeToEnumMapping = new Dictionary<Type, DefinitionsEnum>();
            var mappedTypes =
                Assembly
                    .GetAssembly(typeof(DefinitionAssemblyData))
                    !.GetTypes()
                    .Where(x => x.GetCustomAttributes<DestinyDefinitionAttribute>().Any());

            foreach (var type in mappedTypes)
            {
                var definitionAttribute = type.GetCustomAttribute<DestinyDefinitionAttribute>();
                var enumValue = definitionAttribute!.DefinitionEnumType;
                var useRule = new DefinitionUseRule
                {
                    DefinitionType = type,
                    AttributeData = definitionAttribute
                };
                tempDefinitionsToTypeMapping.Add(enumValue, useRule);
                tempTypeToEnumMapping.Add(useRule.DefinitionType, enumValue);
            }

            DefinitionsToTypeMapping =
                new ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule>(tempDefinitionsToTypeMapping);
            TypeToEnumMapping = new ReadOnlyDictionary<Type, DefinitionsEnum>(tempTypeToEnumMapping);
        }

        public ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        public ReadOnlyDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
    }
}