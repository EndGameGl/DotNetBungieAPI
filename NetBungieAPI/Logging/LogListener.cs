namespace NetBungieAPI.Logging
{
    public class LogListener
    {
        public delegate void NewMessageEvent(LogMessage logMessage);

        public event NewMessageEvent OnNewMessage;

        public void Invoke(LogMessage message)
        {
            OnNewMessage?.Invoke(message);
        }
    }
}