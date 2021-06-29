using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Services
{
    public class DefinitionAssemblyData : IDefinitionAssemblyData
    {
        public DefinitionAssemblyData()
        {
            DefinitionsToTypeMapping = new Dictionary<DefinitionsEnum, DefinitionUseRule>();
            TypeToEnumMapping = new Dictionary<Type, DefinitionsEnum>();
            var mappedTypes =
                Assembly
                    .GetAssembly(typeof(DefinitionAssemblyData))
                    .GetTypes()
                    .Where(x => x.GetCustomAttributes(typeof(DestinyDefinitionAttribute), true).Length > 0);

            foreach (var type in mappedTypes)
            {
                var definitionAttribute =
                    type.GetCustomAttribute(
                            typeof(DestinyDefinitionAttribute),
                            true)
                        as DestinyDefinitionAttribute;
                var enumValue = definitionAttribute.DefinitionEnumType;
                var useRule = new DefinitionUseRule
                {
                    DefinitionType = type,
                    AttributeData = definitionAttribute
                };
                DefinitionsToTypeMapping.Add(enumValue, useRule);
                TypeToEnumMapping.Add(useRule.DefinitionType, enumValue);
            }
        }

        public Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        public Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
    }
}