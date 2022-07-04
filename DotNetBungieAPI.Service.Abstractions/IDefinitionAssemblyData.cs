using System.Collections.ObjectModel;
using DotNetBungieAPI.Models.Destiny;
using DotNetBungieAPI.Service.Abstractions.AssemblyData;

namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Definition assembly data, which maps definition to types and back
/// </summary>
public interface IDefinitionAssemblyData
{
    ReadOnlyDictionary<DefinitionsEnum, DefinitionUseRule> DefinitionsToTypeMapping { get; }
    ReadOnlyDictionary<Type, DefinitionsEnum> TypeToEnumMapping { get; }
}