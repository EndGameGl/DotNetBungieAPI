using DotNetBungieAPI.Attributes;

namespace DotNetBungieAPI.Repositories;

public class DefinitionUseRule
{
    public DestinyDefinitionAttribute AttributeData { get; internal set; }
    public Type DefinitionType { get; internal set; }
}