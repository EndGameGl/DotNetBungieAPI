namespace DotNetBungieAPI.Models.Exceptions;

/// <summary>
///     This exception is thrown when already registered service is readded again
/// </summary>
public class ServiceAlreadyConfiguredException : Exception
{
    /// <summary>
    /// Service type, that was added again
    /// </summary>
    public Type ServiceType { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="serviceType"></param>
    internal ServiceAlreadyConfiguredException(Type serviceType) :
        base($"Service is already configured: {serviceType.FullName}")
    {
        ServiceType = serviceType;
    }
}