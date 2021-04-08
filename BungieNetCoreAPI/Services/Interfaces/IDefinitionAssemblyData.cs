using NetBungieAPI.Destiny;
using NetBungieAPI.Repositories;
using System;
using System.Collections.Generic;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; init; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; init; }
        Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; init; }
        Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; init; }
    }
}
