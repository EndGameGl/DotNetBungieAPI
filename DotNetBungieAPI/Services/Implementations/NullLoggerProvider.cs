using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal class NullLoggerProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
    {
        return new NullLogger(categoryName);
    }

    public void Dispose() { }
}
