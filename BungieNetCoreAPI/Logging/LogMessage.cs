using System;

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
            return StringBuilderPool.GetBuilder().Append("[").Append(Type.ToString()).Append("]: [").Append(Time.ToString()).Append("]: ").Append(Message).ToString();
        }
    }
}
