namespace DotNetBungieAPI.Service.Abstractions;

/// <summary>
///     Interface for a configurable service
/// </summary>
/// <typeparam name="TServiceInterface"></typeparam>
public interface IServiceConfigurator<in TServiceInterface>
    where TServiceInterface : class
{
    /// <summary>
    ///     Registers service implementation and configures options
    /// </summary>
    /// <typeparam name="TServiceImplementation"></typeparam>
    /// <typeparam name="TOptions"></typeparam>
    /// <param name="configure"></param>
    void Use<TServiceImplementation, TOptions>(Action<TOptions> configure)
        where TServiceImplementation : class, TServiceInterface
        where TOptions : class, new();

    /// <summary>
    ///     Registers service implementation
    /// </summary>
    /// <typeparam name="TServiceImplementation"></typeparam>
    void Use<TServiceImplementation>()
        where TServiceImplementation : class, TServiceInterface;
}
