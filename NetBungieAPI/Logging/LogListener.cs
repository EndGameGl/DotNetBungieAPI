namespace NetBungieAPI.Logging
{
    /// <summary>
    /// Log listener
    /// </summary>
    public class LogListener
    {
        /// <summary>
        /// Event delegate
        /// </summary>
        public delegate void NewMessageEvent(LogMessage logMessage);

        /// <summary>
        /// New message received event
        /// </summary>
        public event NewMessageEvent OnNewMessage;

        /// <summary>
        /// Sends new message to listener
        /// </summary>
        /// <param name="message"></param>
        public void Invoke(LogMessage message)
        {
            OnNewMessage?.Invoke(message);
        }
    }
}