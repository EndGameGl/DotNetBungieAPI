using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DotNetBungieAPI.Services.Default.ServiceConfigurations
{
    public sealed class DotNetBungieApiLoggerConfiguration
    {
        private readonly HashSet<LogLevel> _loggedLevels = new HashSet<LogLevel>(7);
        public bool IsEnabled { get; set; } = false;

        public void LogEventLevels(IEnumerable<LogLevel> logLevels)
        {
            foreach (var logLevel in logLevels)
            {
                _loggedLevels.Add(logLevel);
            }
        }

        public bool ShouldLogLevel(LogLevel logLevel) => _loggedLevels.Contains(logLevel);
    }
}