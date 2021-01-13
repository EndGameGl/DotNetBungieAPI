using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Logging
{
    internal static class Logger
    {
        public static List<LogListener> Listeners = new List<LogListener>();
        public static void Log(string message, LogType type)
        {
            if (InternalData.LoggingEnabled)
                Listeners.ForEach(x => x.Invoke(new LogMessage(DateTime.Now, message, type)));
        }

        public static void Register(LogListener newListener)
        {
            Listeners.Add(newListener);
        }
    }
}
