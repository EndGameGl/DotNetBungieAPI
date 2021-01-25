using BungieNetCoreAPI.Destiny;
using BungieNetCoreAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Services
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
        Dictionary<string, DefinitionsEnum> NameToEnumMapping { get; }
        Dictionary<DefinitionsEnum, string> EnumToNameMapping { get; }
    }
}
