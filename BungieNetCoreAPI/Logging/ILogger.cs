using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieApi.Logging
{
    public interface ILogger
    {
        void Log(string message, LogType type);
        void Register(LogListener newListener);
    }
}
