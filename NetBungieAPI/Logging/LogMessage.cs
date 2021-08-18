using System;
using System.Globalization;
using System.Threading;

namespace NetBungieAPI.Logging
{
    /// <summary>
    /// Log message object
    /// </summary>
    public class LogMessage
    {
        internal LogMessage(DateTime time, string message, LogType type)
        {
            Time = time;
            Message = message;
            Type = type;
        }

        /// <summary>
        /// Log time
        /// </summary>
        public DateTime Time { get; }

        /// <summary>
        /// Message to read
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Log type
        /// </summary>
        public LogType Type { get; }

        /// <summary>
        /// <inheritdoc cref="object.ToString"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
                StringBuilderPool
                    .GetBuilder(CancellationToken.None)
                    .Append("[")
                    .Append(Type.ToString())
                    .Append("]: [")
                    .Append(Time.ToString(CultureInfo.InvariantCulture))
                    .Append("]: ")
                    .Append(Message)
                    .Build();
        }
    }
}