using NetBungieApi.Destiny;
using NetBungieApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieApi.Services
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
        Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; }
        Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; }
    }
}
