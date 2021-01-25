﻿using BungieNetCoreAPI.Attributes;
using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BungieNetCoreAPI.Services
{
    public class DefinitionAssemblyData : IDefinitionAssemblyData
    {
        public Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        public Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
        public Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; }
        public Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; }
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
                var enumValue = (DefinitionsEnum)Enum.Parse(typeof(DefinitionsEnum), definitionAttribute.DefinitionName);
                var useRule = new DefinitionUseRule()
                {
                    DefinitionName = definitionAttribute.DefinitionName,
                    DefinitionType = type,
                    IsEnabled = definitionAttribute.ShouldBeLoaded,
                    PresentInSQLiteDB = definitionAttribute.PresentInSQLiteDB,
                    Type = enumValue
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
