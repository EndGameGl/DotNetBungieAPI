using DotNetBungieAPI.Models.Destiny;

namespace DotNetBungieAPI.Services.Implementations.ServiceConfigurations;

public sealed class DefaultDestiny2DefinitionRepositoryConfiguration
{
    private int _appConcurrencyLevel = Environment.ProcessorCount;

    internal List<DefinitionsEnum> AllowedDefinitions { get; } = Enum.GetValues<DefinitionsEnum>().ToList();

    public int AppConcurrencyLevel
    {
        get => _appConcurrencyLevel;
        set => _appConcurrencyLevel = Conditions.Int32MoreThan(value, 0);
    }

    public void IgnoreDefinitionType(DefinitionsEnum definitionType)
    {
        AllowedDefinitions.Remove(definitionType);
    }
}