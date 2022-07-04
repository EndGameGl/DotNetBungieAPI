namespace DotNetBungieAPI.Service.Abstractions;

public interface IServiceConfigurator<in TServiceInterface> where TServiceInterface : class
{
    void Use<TServiceImplementation, TOptions>(Action<TOptions> configure)
        where TServiceImplementation : class, TServiceInterface
        where TOptions : class, new();
    
    void Use<TServiceImplementation>()
        where TServiceImplementation : class, TServiceInterface;
}