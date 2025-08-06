using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Implementations;

internal class NullLogger : ILogger
{
    public string Name { get; }

    public NullLogger(string name)
    {
        Name = name;
    }

    public IDisposable? BeginScope<TState>(TState state)
        where TState : notnull
    {
        return default;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) { }
}
