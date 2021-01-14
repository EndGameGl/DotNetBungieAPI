using System;
using System.Collections.Generic;
using System.Text;

namespace BungieNetCoreAPI.Logging
{
    public interface ILogger
    {
        void Log(string message, LogType type);
        void Register(LogListener newListener);
    }
}
