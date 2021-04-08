using NetBungieAPI.Attributes;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;
using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetBungieAPI.Services
{
    public class DefinitionAssemblyData : IDefinitionAssemblyData
    {
        public Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; init; }
        public Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; init; }
        public Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; init; }
        public Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; init; }
        public DefinitionAssemblyData()
        {
            DefinitionsToTypeMapping = new Dictionary<DefinitionsEnum, DefinitionUseRule>();
            TypeToEnumMapping = new Dictionary<Type, DefinitionsEnum>();
            var mappedTypes =
                 Assembly
                 .GetAssembly(typeof(DefinitionAssemblyData))
                 .GetTypes()
                 .Where(x =>
                 {
                     var attrs = x.GetCustomAttributes(typeof(DestinyDefinitionAttribute), true);
                     return attrs != null && attrs.Length > 0;
                 });

            foreach (var type in mappedTypes)
            {
                var definitionAttribute =
                    type.GetCustomAttribute(
                        attributeType: typeof(DestinyDefinitionAttribute),
                        inherit: true)
                    as DestinyDefinitionAttribute;
                var enumValue = definitionAttribute.DefinitionEnumType;
                var useRule = new DefinitionUseRule()
                {
                    DefinitionStringName = enumValue.ToString(),
                    DefinitionType = type,
                    AttributeData = definitionAttribute,
                    UserOverrideLoadValue = null
                };
                DefinitionsToTypeMapping.Add(enumValue, useRule);
                TypeToEnumMapping.Add(useRule.DefinitionType, enumValue);
            }
            NameToEnumMapping = new Dictionary<string, DefinitionsEnum>();
            EnumToNameMapping = new Dictionary<DefinitionsEnum, string>();
            var enumValues = Enum.GetValues(typeof(DefinitionsEnum)).Cast<DefinitionsEnum>();
            foreach (var enumValue in enumValues)
            {
                var stringEnumValue = enumValue.ToString();
                NameToEnumMapping.Add(stringEnumValue, enumValue);
                EnumToNameMapping.Add(enumValue, stringEnumValue);
            }
        }
    }
}
