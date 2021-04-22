using NetBungieAPI.Services.Interfaces;
using System;
using System.Collections.Generic;

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
            if (_configuration.Settings.InternalSettings.IsLoggingEnabled)
            {
                var messageObject = new LogMessage(DateTime.Now, message, type);
                foreach (var listener in _listeners)
                    listener.Invoke(messageObject);
            }
        }

        public void Register(LogListener newListener)
        {
            _listeners.Add(newListener);
        }
    }
}
