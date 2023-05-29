using System.Collections.ObjectModel;
using DotNetBungieAPI.Models.Destiny;
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
    ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }

    /// <summary>
    ///     Type to enum definitions mapping
    /// </summary>
    ReadOnlyDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
}
