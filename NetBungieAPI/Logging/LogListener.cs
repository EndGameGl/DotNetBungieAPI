using System;
using System.Collections.Generic;
using System.Text;

namespace NetBungieAPI.Logging
{
    public class LogListener
    {
        public event NewMessageEvent OnNewMessage;
        public delegate void NewMessageEvent(LogMessage logMessage);

        public void Invoke(LogMessage message)
        {
            OnNewMessage?.Invoke(message);
        }
    }
}
