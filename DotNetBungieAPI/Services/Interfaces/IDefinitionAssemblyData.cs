using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Repositories;

namespace DotNetBungieAPI.Services.Interfaces
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