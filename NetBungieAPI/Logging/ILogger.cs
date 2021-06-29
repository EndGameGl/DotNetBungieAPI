namespace NetBungieAPI.Logging
{
    public interface ILogger
    {
        void Log(string message, LogType type);
        void Register(LogListener newListener);
    }
}