using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Logging
{
    public class LogMessage
    {
        public DateTime Time { get; }
        public string Message { get; }
        public LogType Type { get; }

        internal LogMessage(DateTime time, string message, LogType type)
        {
            Time = time;
            Message = message;
            Type = type;
        }

        public override string ToString()
        {
            return $"[{Type}]: [{Time}]: {Message}";
        }
    }
}
