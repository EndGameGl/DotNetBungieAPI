using System.Collections.Frozen;
using DotNetBungieAPI.Models;
using DotNetBungieAPI.Service.Abstractions.AssemblyData;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Definition assembly data, which maps definition to types and back
/// </summary>
public interface IDefinitionAssemblyData
{
    /// <summary>
    ///     Definition use rules, keyed by definition types
    /// </summary>
    FrozenDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }

    /// <summary>
    ///     Type to enum definitions mapping
    /// </summary>
    FrozenDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
}
