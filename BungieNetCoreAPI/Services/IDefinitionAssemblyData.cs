using NetBungieAPI.Destiny;
using NetBungieAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Services
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
        Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; }
        Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; }
    }
}
