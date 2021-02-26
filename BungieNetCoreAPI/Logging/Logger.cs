using BungieNetCoreAPI.Clients;
using BungieNetCoreAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace BungieNetCoreAPI.Logging
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
            if (_configuration.Settings.EnableLogging)
                _listeners.ForEach(x => x.Invoke(new LogMessage(DateTime.Now, message, type)));
        }

        public void Register(LogListener newListener)
        {
            _listeners.Add(newListener);
        }
    }
}
