using DotNetBungieAPI.Service.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.ApiBuilder;

/// <summary>
///     Class to configure bungie client service
/// </summary>
/// <typeparam name="TServiceInterface"></typeparam>
internal class ServiceConfigurator<TServiceInterface> : IServiceConfigurator<TServiceInterface>
    where TServiceInterface : class
{
    private readonly IServiceCollection _serviceCollection;
    internal bool IsConfigured { get; set; }

    public ServiceConfigurator(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void Use<TServiceImplementation, TOptions>(
        Action<TOptions> configure)
        where TServiceImplementation : class, TServiceInterface
        where TOptions : class, new()
    {
        var options = new TOptions();
        configure(options);
        _serviceCollection.AddSingleton<TServiceInterface, TServiceImplementation>();
        _serviceCollection.AddSingleton(options);
    }

    public void Use<TServiceImplementation>() where TServiceImplementation : class, TServiceInterface
    {
        _serviceCollection.AddSingleton<TServiceInterface, TServiceImplementation>();
    }
}