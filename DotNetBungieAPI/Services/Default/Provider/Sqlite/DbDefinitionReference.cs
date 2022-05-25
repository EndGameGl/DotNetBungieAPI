using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Services.Default.Provider.Sqlite;

public struct DbDefinitionReference
{
    public DefinitionsEnum DefinitionType { get; }
    public uint Hash { get; }

    public DbDefinitionReference(DefinitionsEnum definitionType, uint hash)
    {
        DefinitionType = definitionType;
        Hash = hash;
    }
}