using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;
using System;
using System.Collections.Generic;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
    }
}
