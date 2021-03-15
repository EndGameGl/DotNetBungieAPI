using NetBungieAPI.Clients;
using NetBungieAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace NetBungieAPI.Logging
{
    internal class Logger : ILogger
    {
        private readonly IConfigurationService _configuration;
        private List<LogListener> _listeners = new List<LogListener>();

        public Logger(IConfigurationService config)
        {
            _configuration = config;
        }
        public void Log(string message, LogType type)
        {
            if (_configuration.Settings.IsLoggingEnabled)
                _listeners.ForEach(x => x.Invoke(new LogMessage(DateTime.Now, message, type)));
        }

        public void Register(LogListener newListener)
        {
            _listeners.Add(newListener);
        }
    }
}
