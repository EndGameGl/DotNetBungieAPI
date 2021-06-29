using System;
using System.Collections.Generic;
using NetBungieAPI.Services.Interfaces;

namespace NetBungieAPI.Logging
{
    internal class Logger : ILogger
    {
        private readonly IConfigurationService _configuration;
        private readonly List<LogListener> _listeners = new();

        public Logger(IConfigurationService config)
        {
            _configuration = config;
        }

        public void Log(string message, LogType type)
        {
            if (!_configuration.Settings.InternalSettings.IsLoggingEnabled)
                return;

            var messageObject = new LogMessage(DateTime.Now, message, type);
            foreach (var listener in _listeners)
                listener.Invoke(messageObject);
        }

        public void Register(LogListener newListener)
        {
            _listeners.Add(newListener);
        }
    }
}