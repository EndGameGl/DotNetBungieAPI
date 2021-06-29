using System;
using System.Collections.Generic;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;

namespace NetBungieAPI.Services.Interfaces
{
    public interface IDefinitionAssemblyData
    {
        Dictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        Dictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
    }
}