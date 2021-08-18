namespace NetBungieAPI.Logging
{
    /// <summary>
    /// Simple logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs new message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        void Log(string message, LogType type);

        /// <summary>
        /// Registers new listener
        /// </summary>
        /// <param name="newListener"></param>
        void Register(LogListener newListener);
    }
}