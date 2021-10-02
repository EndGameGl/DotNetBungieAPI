using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NetBungieAPI.Models.Destiny;
using NetBungieAPI.Repositories;

namespace NetBungieAPI.Services.Interfaces
{
    /// <summary>
    /// Definition assembly data, which maps definition to types and back
    /// </summary>
    public interface IDefinitionAssemblyData
    {
        ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
        ReadOnlyDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
    }
}