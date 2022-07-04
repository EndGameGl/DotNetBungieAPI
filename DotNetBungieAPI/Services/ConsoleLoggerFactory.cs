using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services;

public class ConsoleLoggerFactory : ILoggerFactory
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName)
    {
        throw new NotImplementedException();
    }

    public void AddProvider(ILoggerProvider provider)
    {
        throw new NotImplementedException();
    }
}